using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPhysicsController : MonoBehaviour
{
    public Rigidbody2D shipPhysicsRB2D;
    public GameObject home_planet;
    private Rigidbody2D hpRB2D;
    private CircleCollider2D hpCC2D;
    public Transform shipGraphicsTransform;
    public Vector3 shipForward;
    public float thrustMagnitude = 0.05f;
    public int thrustKeyDownMult;

    public float altitude;

    void Start()
    {
        hpRB2D = home_planet.GetComponent<Rigidbody2D>();
        hpCC2D = home_planet.GetComponent<CircleCollider2D>();
        thrustKeyDownMult = 0;
    }

    // Update is called once per frame
    void Update()
    {
        altitude = (shipPhysicsRB2D.position - hpRB2D.position).magnitude - hpCC2D.radius * 4;
        shipPhysicsRB2D.drag = -0.5f / (1 + Mathf.Pow(2.7182f, -1.4f * altitude + 2)) + 0.5000000005f;

        shipForward = gameObject.transform.up;
        if (Input.GetKey(KeyCode.Space))
            thrustKeyDownMult = 1;
        else
            thrustKeyDownMult = 0;
    }

    void FixedUpdate()
    {
        shipPhysicsRB2D.AddForce(shipGraphicsTransform.transform.up * (thrustMagnitude * thrustKeyDownMult), ForceMode2D.Impulse);
    }
}
