using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate_Bodies : MonoBehaviour
{
    public GameObject body_to_instantiate;
    public GameObject parent_body;
    public int num_of_bodies = 1; // Must be >= 0
    public string spawn_distribution = "Uniform"; // Uniform, Random, Clump
    public string orbit_type = "Circular"; // Circular, Mild E, Moderate E, High E, Escape
    public float base_mass = 10; // Minimum mass.
    public float mass_variance = 1; // Multiplier that randomizes mass.
    public float base_size = 1; // Minimum size.
    public float size_variance = 1; // Multiplier that randomizes size.
    public float altitude_mult = 2; // Must be > 1.0
    public float altitude_variance = 1; // Multiplier that upward randomness to the altitude at which objects spawn.

    void Start()
    {
        if (num_of_bodies < 0)
            num_of_bodies = 0;
        if (altitude_mult < 1)
            altitude_mult = 1;

        Rigidbody2D bodyRB2D = body_to_instantiate.GetComponent<Rigidbody2D>();
        Rigidbody2D parentRB2D = parent_body.GetComponent<Rigidbody2D>();
        CircleCollider2D parentCC2D = parent_body.GetComponent<CircleCollider2D>();

        float obj_distance = parentCC2D.radius * altitude_mult;
        float spawn_speed = Mathf.Sqrt(0.6674f * parentRB2D.mass / obj_distance);
        Vector2 spawn_pos;

        for (int i = 0; i < num_of_bodies; i++)
        {
            spawn_pos = parentRB2D.position + Random.insideUnitCircle.normalized * obj_distance * Random.Range(1, altitude_variance);

            GameObject instance = Instantiate(body_to_instantiate, spawn_pos, Quaternion.identity);
            Rigidbody2D instanceRB2D = instance.GetComponent<Rigidbody2D>();

            Vector2 radial_vector = instanceRB2D.position - parentRB2D.position;
            instanceRB2D.velocity = Vector3.Cross(radial_vector, Vector3.forward).normalized * spawn_speed;
            instanceRB2D.mass = Random.Range(base_mass, base_mass * mass_variance);
            float instance_radius = Random.Range(base_size, base_size * size_variance);
            instance.transform.localScale = new Vector3(instance_radius, instance_radius, 1);
        }
    }
}
