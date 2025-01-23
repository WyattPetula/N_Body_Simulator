using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atmosphere_Behavior : MonoBehaviour
{
    public float fire_duration = 0.1f;

    IEnumerator EnableTrail(Collider2D collision)
    {
        TrailRenderer trail_renderer = collision.gameObject.GetComponent<TrailRenderer>();
        trail_renderer.widthMultiplier = 1;
        trail_renderer.time = 0;

        WaitForSeconds wait = new WaitForSeconds(0.001f);
        while (trail_renderer.time < 0.5f)
        {
            trail_renderer.time += fire_duration;
            yield return wait; 
        }
    }

    IEnumerator DisableTrail(Collider2D collision)
    {
        TrailRenderer trail_renderer = collision.gameObject.GetComponent<TrailRenderer>();
        WaitForSeconds wait = new WaitForSeconds(0.0005f);

        while (trail_renderer.time > 0)
        {
            trail_renderer.time -= fire_duration;
            yield return wait; 
        }

        trail_renderer.widthMultiplier = 0;
        trail_renderer.time = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Minor Body")
        {
            StartCoroutine(EnableTrail(collision));
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Minor Body")
        {
            StartCoroutine(DisableTrail(collision));  
        }
    }
}