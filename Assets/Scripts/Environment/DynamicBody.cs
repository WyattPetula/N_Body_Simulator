using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicBody : MonoBehaviour
{
    const float g = 0.6674f;
    public float ship_force_mult = 1;
    private float applied_mult = 1;


    public static List<DynamicBody> dynamicBodiesList;

    public Rigidbody2D rb2D;

    void Awake()
    {

    }
    void Start()
    {
    }

    void FixedUpdate()
    {
        DynamicBody[] dynamicBodiesArray = FindObjectsOfType<DynamicBody>();
        foreach(DynamicBody dynamicBody in dynamicBodiesArray)
        {
            if (dynamicBody != this)
                Attract(dynamicBody);
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

    void Attract (DynamicBody objectToAttract)
    {
        Rigidbody2D rb2DToAttract = objectToAttract.rb2D;

        Vector2 direction = rb2D.position - rb2DToAttract.position;
        float distance = direction.magnitude;

        float forceMagnitude = g * (rb2D.mass * rb2DToAttract.mass) / Mathf.Pow(distance, 2);

        Vector2 force = direction.normalized * forceMagnitude;

        rb2DToAttract.AddForce(force);
    
    }
}
