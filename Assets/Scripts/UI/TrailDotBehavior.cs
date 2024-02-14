using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailDotBehavior : MonoBehaviour
{
    public float dotLifetime;
    // Start is called before the first frame update
    void Start()
    {
        dotLifetime = 10f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        dotLifetime -= Time.deltaTime;

        if (dotLifetime <= 0)
            Destroy(gameObject);
    }
}
