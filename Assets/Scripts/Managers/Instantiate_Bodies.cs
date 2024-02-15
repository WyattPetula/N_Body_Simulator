using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate_Bodies : MonoBehaviour
{
    public GameObject body_to_instantiate;
    public GameObject parent_body;
    public int num_of_bodies = 1; // Must be >= 0
    public string spawn_distribution = "Random"; // Uniform, Random.
    public float clump_multiplier = 1; // OPTIONAL. Uniformly clumps bodies in a segment of an orbit for decimal values and non-uniformly for values > 1.
    public float clump_offset = 0; // OPTIONAL. Offsets a clump along an orbit (value is multiplied by 2 PI).
    public string orbit_type = "Circular"; // Vertical, Suborbital, Grazing, Inward E, Circular, Mild E, Moderate E, High E, Escape.
    public float base_mass = 10; // Minimum mass.
    public float mass_variance = 1; // Multiplier that randomizes mass.
    public float base_size = 1; // Minimum size.
    public float size_variance = 1; // Multiplier that randomizes size.
    public float altitude_mult = 2; // Must be > 1.0
    public float altitude_variance = 1; // Multiplier that upward randomness to the altitude at which objects spawn.
    public float vertical_speed = 0; // OPTIONAL. To be used for vertical orbit type.

    void Start()
    {
        if (num_of_bodies < 0)
            num_of_bodies = 0;
        if (altitude_mult < 1)
            altitude_mult = 1;

        Rigidbody2D bodyRB2D = body_to_instantiate.GetComponent<Rigidbody2D>();
        Rigidbody2D parentRB2D = parent_body.GetComponent<Rigidbody2D>();
        CircleCollider2D parentCC2D = parent_body.GetComponent<CircleCollider2D>();

        float spawn_speed;
        float obj_distance = parentCC2D.radius * altitude_mult;

        // Calculate initial body velocity based on orbit type.
        if (orbit_type == "Vertical")
            spawn_speed = -vertical_speed;
        else if (orbit_type == "Suborbital")
            spawn_speed = Mathf.Sqrt(0.3f * 0.6674f * parentRB2D.mass / obj_distance);
        else if (orbit_type == "Grazing")
            spawn_speed = Mathf.Sqrt(0.6f * 0.6674f * parentRB2D.mass / obj_distance);
        else if (orbit_type == "Inward E")
            spawn_speed = Mathf.Sqrt(0.8f * 0.6674f * parentRB2D.mass / obj_distance);
        else if (orbit_type == "Circular")
            spawn_speed = Mathf.Sqrt(0.6674f * parentRB2D.mass / obj_distance);
        else if (orbit_type == "Mild E")
            spawn_speed = Mathf.Sqrt(1.2f * 0.6674f * parentRB2D.mass / obj_distance);
        else if (orbit_type == "Moderate E")
            spawn_speed = Mathf.Sqrt(1.4f * 0.6674f * parentRB2D.mass / obj_distance);
        else if (orbit_type == "High E")
            spawn_speed = Mathf.Sqrt(1.6f * 0.6674f * parentRB2D.mass / obj_distance);
        else if (orbit_type == "Escape")
            spawn_speed = Mathf.Sqrt(2 * 0.6674f * parentRB2D.mass / obj_distance);
        else
            spawn_speed = 0;
        
        Vector2 spawn_pos;

        for (int i = 0; i < num_of_bodies; i++)
        {
            // Calculate spawn positions.
            if (spawn_distribution == "Random")
                spawn_pos = parentRB2D.position + Random.insideUnitCircle.normalized * obj_distance * Random.Range(1, altitude_variance);
            else //Default is uniform.
            {
                float radians = (i * 2 * Mathf.PI / num_of_bodies) * clump_multiplier + clump_offset * Mathf.PI;
                float vertical = Mathf.Sin(radians);
                float horizontal = Mathf.Cos(radians);
                spawn_pos = parentRB2D.position + new Vector2(horizontal, vertical) * obj_distance * Random.Range(1, altitude_variance);
            }

            // Instantiate bodies.
            GameObject instance = Instantiate(body_to_instantiate, spawn_pos, Quaternion.identity);
            Rigidbody2D instanceRB2D = instance.GetComponent<Rigidbody2D>();

            // Initialize instances' initial velocities.
            Vector2 radial_vector = instanceRB2D.position - parentRB2D.position;
            
            if (orbit_type == "Vertical")
                instanceRB2D.velocity = -radial_vector * spawn_speed;
            else
                instanceRB2D.velocity = Vector3.Cross(radial_vector, Vector3.forward).normalized * spawn_speed;

            // Calculate instances' masses and sizes.
            instanceRB2D.mass = Random.Range(base_mass, base_mass * mass_variance);
            float instance_radius = Random.Range(base_size, base_size * size_variance);
            instance.transform.localScale = new Vector3(instance_radius, instance_radius, 1);
        }
    }
}
