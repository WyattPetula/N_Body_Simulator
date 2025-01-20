using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Instantiate_Bodies : MonoBehaviour
{
    // DOCUMENTATION 

    //public float clump_multiplier = 1; // OPTIONAL. Uniformly clumps bodies in a segment of an orbit for decimal values and non-uniformly for values > 1.
    //public float clump_offset = 0; // OPTIONAL. Offsets a clump along an orbit (value is multiplied by 2 PI).
    //public string orbit_type = "Circular"; // Vertical, Suborbital, Grazing, Inward E, Circular, Mild E, Moderate E, High E, Escape.
    //public float mass_variance = 1; // Multiplier that randomizes mass.
    //public float size_variance = 1; // Multiplier that randomizes size.
    //public float altitude_mult = 2; // Must be > 1.0
    //public float altitude_variance = 1; // Multiplier that upward randomness to the altitude at which objects spawn.
    //public float vertical_speed = 0; // OPTIONAL. To be used for vertical orbit type.

    private List<Config> configs_list = new List<Config>();

    public void Run_Simulation()
    {
        GameObject config_container = GameObject.Find("Content");

        // Avoid stacking duplicates into the Global config list.
        configs_list.Clear();

        foreach(RectTransform config_transform in config_container.transform){
            configs_list.Add(config_transform.gameObject.GetComponent<Config>());
        }

        // Apply each config to the simulation.
        foreach(Config config in configs_list)
        {
            if(config.config_enabled == "Active"){
                // Avoid game-breaking values.
                if (config.num_of_bodies < 0)
                    config.num_of_bodies = 0;
                if (config.altitude_mult < 0)
                    config.altitude_mult = 0;

                Rigidbody2D parentRB2D = config.parent_body.GetComponent<Rigidbody2D>();
                CircleCollider2D parentCC2D = config.parent_body.GetComponent<CircleCollider2D>();

                float spawn_speed;
                float obj_distance = parentCC2D.radius * 4 + config.altitude_mult * 10;

                // Determine spawn speed.
                if (config.orbit_type == 1) spawn_speed = Mathf.Sqrt(0.6674f * parentRB2D.mass / obj_distance);
                else spawn_speed = config.orbit_type * Mathf.Sqrt(0.6674f * parentRB2D.mass / obj_distance);

                Vector2 spawn_pos;

                for (int i = 0; i < config.num_of_bodies; i++)
                {
                    // Spawn objects randomly along a circle
                    if (config.spawn_distribution == "Random")
                        spawn_pos = parentRB2D.position + Random.insideUnitCircle.normalized * obj_distance * Random.Range(1, config.altitude_var);
                    
                    // Evenly clump objects along a specified circle segment.
                    else
                    {
                        float radians = i * 2 * Mathf.PI / config.num_of_bodies * config.clump_mult + config.clump_offset * Mathf.PI;
                        float vertical = Mathf.Sin(radians); 
                        float horizontal = Mathf.Cos(radians);
                        spawn_pos = parentRB2D.position + new Vector2(horizontal, vertical).normalized * obj_distance * Random.Range(1, config.altitude_var);
                    }

                    // Instantiate bodies.
                    GameObject instance = Instantiate(config.body_to_spawn, spawn_pos, Quaternion.identity);
                    Rigidbody2D instanceRB2D = instance.GetComponent<Rigidbody2D>();

                    // Save all spawned bodies to a Global list.
                    Globals.spawned_objects.Add(instance);

                    // Initialize instance velocities.
                    Vector2 radial_vector = instanceRB2D.position - parentRB2D.position;
                    instanceRB2D.velocity = Vector3.Cross(radial_vector, Vector3.forward).normalized * spawn_speed + (Vector3)(radial_vector * config.vertical_velocity);

                    // Apply specified instance masses and sizes.
                    instanceRB2D.mass = Random.Range(config.default_mass, config.default_mass * config.mass_var);
                    float instance_radius = Random.Range(config.default_size, config.default_size * config.size_var);
                    instance.transform.localScale = new Vector3(instance_radius, instance_radius, 1);
                }
            }
        }
    }
}
