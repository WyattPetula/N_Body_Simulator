using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class Reset_Sim : MonoBehaviour
{
    public GameObject celestial_body;
    public GameObject inner_moon;
    public GameObject outer_moon;
    public GameObject player;
    public void Reset_Simulator(){
        // Brute force reluctant objects to reset.
        for(int i = 0; i <= 5; i++)
        {
            // Delete all spawned objects.
            foreach(GameObject spawned_body in Globals.spawned_objects){
                Destroy(spawned_body);
            }

            Debug.Log("Destroyed all spawned objects");
            
            Rigidbody2D celestial_body_rb2D = celestial_body.GetComponent<Rigidbody2D>();
            Rigidbody2D inner_body_rb2D = inner_moon.GetComponent<Rigidbody2D>();
            Rigidbody2D outer_body_rb2D = outer_moon.GetComponent<Rigidbody2D>();
            Rigidbody2D player_rb2D = player.GetComponent<Rigidbody2D>();

            // Reset velocities to zero for reset prep.
            player_rb2D.velocity = new Vector3(0, 0, 0);
            celestial_body_rb2D.velocity = new Vector3(0, 0, 0);
            inner_body_rb2D.velocity = new Vector3(0, 0, 0);
            outer_body_rb2D.velocity = new Vector3(0, 0, 0);

            // Reset celestial bodies to starting positions.
            celestial_body_rb2D.MovePosition(Constants.celestial_body_startpos);
            player_rb2D.MovePosition(Constants.player_startpos);
            inner_body_rb2D.MovePosition(Constants.inner_moon_startpos);
            outer_body_rb2D.MovePosition(Constants.outer_moon_startpos);

            // Reset inner and outer moons' initial velocities.
            Vector2 inner_radial_vector = inner_body_rb2D.position - celestial_body_rb2D.position;
            float inner_spawn_speed = Mathf.Sqrt(0.6674f * celestial_body_rb2D.mass / inner_radial_vector.magnitude);
            inner_body_rb2D.velocity = Vector3.Cross(inner_radial_vector, Vector3.forward).normalized * inner_spawn_speed;

            Vector2 outer_radial_vector = outer_body_rb2D.position - celestial_body_rb2D.position;
            float outer_spawn_speed = Mathf.Sqrt(0.6674f * celestial_body_rb2D.mass / outer_radial_vector.magnitude);
            outer_body_rb2D.velocity = Vector3.Cross(outer_radial_vector, Vector3.forward).normalized * outer_spawn_speed;

            Debug.Log("Reset all celestial and player dynamics");
        }
    }
    public void Reset_Objects() {
        foreach(GameObject spawned_body in Globals.spawned_objects){
            Destroy(spawned_body);
        }
    }
}
