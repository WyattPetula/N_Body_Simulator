using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atmosphere_Behavior : MonoBehaviour
{
    public float fire_duration = 0.1f;
    // Start is called before the first frame update
    IEnumerator EnableTrail(Collider2D collision)
    {
        //Declare a yield instruction.
        TrailRenderer trail_renderer = collision.gameObject.GetComponent<TrailRenderer>();
        trail_renderer.widthMultiplier = 1;
        trail_renderer.time = 0;

        WaitForSeconds wait = new WaitForSeconds(0.001f);
        Debug.Log("UP1");
        while (trail_renderer.time < 0.5f)
        {
            Debug.Log("UP2");
            trail_renderer.time += fire_duration;
            yield return wait; 
        }
    }

    IEnumerator DisableTrail(Collider2D collision)
    {
        //Declare a yield instruction.
        TrailRenderer trail_renderer = collision.gameObject.GetComponent<TrailRenderer>();
        WaitForSeconds wait = new WaitForSeconds(0.0005f);

        Debug.Log("DOWN1");
        while (trail_renderer.time > 0)
        {
            Debug.Log("DOWN2");
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
            Debug.Log("COLLISION ENTER");
            StartCoroutine(EnableTrail(collision));
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Minor Body")
        {
            Debug.Log("COLLISION EXIT");
            StartCoroutine(DisableTrail(collision));  
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
