using System.Collections;
using UnityEngine;

public class Reset_Sim : MonoBehaviour
{
    public GameObject celestial_body;
    public GameObject inner_moon;
    public GameObject outer_moon;
    public GameObject player;
    public void Reset_Simulator(){
        Globals.freeze_simulation = true;

        // Delete spawned objects.
        foreach(GameObject spawned_body in Globals.spawned_objects){
            Destroy(spawned_body);
        }
        
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
        celestial_body_rb2D.position = Constants.celestial_body_startpos;
        player_rb2D.position = Constants.player_startpos;
        inner_body_rb2D.position = Constants.inner_moon_startpos;
        outer_body_rb2D.position = Constants.outer_moon_startpos;

        // Reset celestial bodies' initial velocities.
        Vector2 inner_radial_vector = inner_body_rb2D.position - celestial_body_rb2D.position;
        float inner_spawn_speed = Mathf.Sqrt(0.6674f * celestial_body_rb2D.mass / inner_radial_vector.magnitude);
        inner_body_rb2D.velocity = Vector3.Cross(inner_radial_vector, Vector3.forward).normalized * inner_spawn_speed;

        Vector2 outer_radial_vector = outer_body_rb2D.position - celestial_body_rb2D.position;
        float outer_spawn_speed = Mathf.Sqrt(0.6674f * celestial_body_rb2D.mass / outer_radial_vector.magnitude);
        outer_body_rb2D.velocity = Vector3.Cross(outer_radial_vector, Vector3.forward).normalized * outer_spawn_speed;

        Globals.freeze_simulation = false;
    }
    public void Reset_Objects() {
        // Delete spawned objects.
        foreach(GameObject spawned_body in Globals.spawned_objects){
            Destroy(spawned_body);
        }
    }
}
