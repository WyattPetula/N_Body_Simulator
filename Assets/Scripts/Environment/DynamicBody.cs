using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicBody : MonoBehaviour
{
    const float g = 0.6674f;
    public float ship_force_add = 1.3f;

    public static List<DynamicBody> dynamicBodiesList;

    public Rigidbody2D rb2D;

    void Awake()
    {

    }
    void Start()
    {
        if(gameObject.name == "Moon 1" || gameObject.name == "Moon 2")
        {
            Rigidbody2D mainBody = GameObject.Find("Celestial Body").GetComponent<Rigidbody2D>();
            Vector2 radial_vector = rb2D.position - mainBody.position;
            float spawn_speed = Mathf.Sqrt(0.6674f * mainBody.mass / radial_vector.magnitude);
            rb2D.velocity = Vector3.Cross(radial_vector, Vector3.forward).normalized * spawn_speed;
        }
    }
    
    void FixedUpdate()
    {
        DynamicBody[] dynamicBodiesArray = FindObjectsOfType<DynamicBody>();
        foreach(DynamicBody dynamicBody in dynamicBodiesArray)
        {
            //Debug.Log(dynamicBody.gameObject.name);
            if (dynamicBody != this)
                if(dynamicBody.name != "Ship Physics")
                    Attract(dynamicBody, 0);
                else if (gameObject.name != "Bomb(Clone)")
                    Attract(dynamicBody, ship_force_add);
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

    void Attract (DynamicBody objectToAttract, float ship_force_add)
    {
        Rigidbody2D rb2DToAttract = objectToAttract.rb2D;

        Vector2 direction = rb2D.position - rb2DToAttract.position;
        float distance = direction.magnitude;

        float forceMagnitude = g * (rb2D.mass + ship_force_add) * rb2DToAttract.mass / Mathf.Pow(distance, 2);

        Vector2 force = direction.normalized * forceMagnitude;

        rb2DToAttract.AddForce(force);
    
    }
}
