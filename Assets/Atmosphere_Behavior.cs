using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atmosphere_Behavior : MonoBehaviour
{
    public float fire_duration = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    IEnumerator EnableTrail(Collider2D collision)
    {
        //Declare a yield instruction.
        TrailRenderer trail_renderer = collision.gameObject.GetComponent<TrailRenderer>();
        trail_renderer.time = 0;

        WaitForSeconds wait = new WaitForSeconds(0.1f);

        while (trail_renderer.time < 0.5f)
        {
            trail_renderer.time += fire_duration;
            yield return wait; 
        }
    }

    IEnumerator DisableTrail(Collider2D collision)
    {
        //Declare a yield instruction.
        TrailRenderer trail_renderer = collision.gameObject.GetComponent<TrailRenderer>();
        WaitForSeconds wait = new WaitForSeconds(0.1f);

        while (trail_renderer.time > 0)
        {
            trail_renderer.time -= fire_duration;
            yield return wait; 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Minor Body")
        {
            EnableTrail(collision);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Minor Body")
        {
            DisableTrail(collision);  
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
