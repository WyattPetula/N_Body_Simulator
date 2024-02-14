using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestParameters : MonoBehaviour
{
    public Rigidbody2D objectRB2D;
    public GameObject parent_body;
    public Rigidbody2D parentRB2D;
    public CircleCollider2D parentCC2D;
    public float altitude_mult;
    public float custom_spawn_vel;
    // Start is called before the first frame update
    void Start()
    {
        objectRB2D = GetComponent<Rigidbody2D>();
        parentRB2D = parent_body.GetComponent<Rigidbody2D>();
        parentCC2D = parent_body.GetComponent<CircleCollider2D>();
        
        float obj_distance = parentCC2D.radius * altitude_mult;
        objectRB2D.position = parentRB2D.position + Random.insideUnitCircle.normalized * obj_distance;
        Vector2 radial_vector = objectRB2D.position - parentRB2D.position;
        float spawn_velocity = Mathf.Sqrt(0.6674f * parentRB2D.mass / obj_distance);
        objectRB2D.velocity = Vector3.Cross(radial_vector, Vector3.forward).normalized * spawn_velocity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
