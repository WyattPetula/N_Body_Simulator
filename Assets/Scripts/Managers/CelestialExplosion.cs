using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialExplosion : MonoBehaviour
{
    private GameObject home_planet;
    private Rigidbody2D hpRB2D;
    private CircleCollider2D hpCC2D;
    private Rigidbody2D objectRB2D;
    public ParticleSystem explosion_effect;

    public float altitude;
    private bool explosion_occured;

    void Start()
    {
        home_planet = GameObject.Find("Celestial Body");
        hpRB2D = home_planet.GetComponent<Rigidbody2D>();
        hpCC2D = home_planet.GetComponent<CircleCollider2D>();
        objectRB2D = gameObject.GetComponent<Rigidbody2D>();

        explosion_occured = false;
    }

    void Update()
    {
        altitude = (objectRB2D.position - hpRB2D.position).magnitude - hpCC2D.radius * 4;

        if(altitude <= 1f && !explosion_occured && objectRB2D.velocity.magnitude > 21)
        {
            Instantiate(explosion_effect, objectRB2D.position, Quaternion.FromToRotation(Vector3.up, (objectRB2D.position - hpRB2D.position)).normalized);
            Destroy(gameObject);
        }
    }
}
