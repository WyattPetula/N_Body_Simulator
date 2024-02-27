using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatingEffect : MonoBehaviour
{
    private GameObject home_planet;
    private Rigidbody2D hpRB2D;
    private CircleCollider2D hpCC2D;
    private Rigidbody2D objectRB2D;
    private TrailRenderer trail_renderer;

    public float fire_duration = 0.01f;
    private float altitude;
    private bool in_atmo;
    public float drag;
    // Start is called before the first frame update
    void Start()
    {
        home_planet = GameObject.Find("Celestial Body");
        hpRB2D = home_planet.GetComponent<Rigidbody2D>();
        hpCC2D = home_planet.GetComponent<CircleCollider2D>();
        objectRB2D = gameObject.GetComponent<Rigidbody2D>();
        trail_renderer = gameObject.GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        altitude = (objectRB2D.position - hpRB2D.position).magnitude - hpCC2D.radius * 4;
        objectRB2D.drag = -0.5f / (1 + Mathf.Pow(2.7182f, -1.4f * altitude + 2)) + 0.5000000005f;

        if (altitude <= 5)
        {
            if (in_atmo == false)
            {
                in_atmo = true;
                StopCoroutine(DisableTrail());
                StartCoroutine(EnableTrail());
            }
        }
        else
        {
            if(in_atmo == true)
            {
                in_atmo = false;
                StopCoroutine(EnableTrail());
                StartCoroutine(DisableTrail());
            }
        }        
    }

    IEnumerator EnableTrail()
    {
        //trail_renderer.widthMultiplier = 1;
        //trail_renderer.time = 0;

        WaitForSeconds wait = new WaitForSeconds(0.01f);
        while (trail_renderer.time < 0.5f)
        {
            trail_renderer.time += 0.01f;
            yield return wait;
        }
    }

    IEnumerator DisableTrail()
    {
        WaitForSeconds wait2 = new WaitForSeconds(0.0075f);

        while (trail_renderer.time > 0)
        {
            trail_renderer.time -= 0.01f;
            yield return wait2;
        }

        //trail_renderer.widthMultiplier = 0;
        //trail_renderer.time = 0;
    }
}
