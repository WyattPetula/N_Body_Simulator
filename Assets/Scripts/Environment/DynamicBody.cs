using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicBody : MonoBehaviour
{
    const float g = 0.6674f;
    public float ship_force_add = 1.3f;

    public static List<DynamicBody> dynamicBodiesList;

    public Rigidbody2D rb2D;
    void Start()
    {
        // Initialize celestial dynamics.
        if(gameObject.name == "Inner Moon" || gameObject.name == "Outer Moon")
        {
            Rigidbody2D mainBody = GameObject.Find("Celestial Body").GetComponent<Rigidbody2D>();
            Vector2 radial_vector = rb2D.position - mainBody.position;
            float spawn_speed = Mathf.Sqrt(0.6674f * mainBody.mass / radial_vector.magnitude);
            rb2D.velocity = Vector3.Cross(radial_vector, Vector3.forward).normalized * spawn_speed;
        }
    }
    
    void FixedUpdate()
    {
        if(!Globals.freeze_simulation){
            DynamicBody[] dynamicBodiesArray = FindObjectsOfType<DynamicBody>();

            foreach (DynamicBody dynamicBody in dynamicBodiesArray)
            {
                if (dynamicBody == this) continue;

                // Avoid unwanted forces between some objects.
                float forceToAdd = (dynamicBody.name == "Ship Physics" && gameObject.name != "Bomb(Clone)") 
                                ? ship_force_add 
                                : 0;

                Attract(dynamicBody, forceToAdd);
            }
        }
    }

    void OnEnabled()
    {
        if (dynamicBodiesList == null)
            dynamicBodiesList = new List<DynamicBody>();
       
        dynamicBodiesList.Add(this);
    }

    void OnDisabled()
    {
        dynamicBodiesList.Remove(this);
    }

    void Attract(DynamicBody objectToAttract, float ship_force_add)
    {
        Rigidbody2D rb2DToAttract = objectToAttract.rb2D;

        Vector2 direction = rb2D.position - rb2DToAttract.position;
        float distanceSquared = direction.sqrMagnitude;

        float forceMagnitude = g * (rb2D.mass + ship_force_add) * rb2DToAttract.mass / distanceSquared;
        Vector2 force = direction * (forceMagnitude / Mathf.Sqrt(distanceSquared));

        rb2DToAttract.AddForce(force);
    }
}
