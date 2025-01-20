using System.Collections;
using UnityEngine;

public class TrailDotBehavior : MonoBehaviour
{
    public float dotLifetime;
    void Start()
    {
        dotLifetime = 10f;
    }

    void FixedUpdate()
    {
        dotLifetime -= Time.deltaTime;

        if (dotLifetime <= 0)
            Destroy(gameObject);
    }
}
