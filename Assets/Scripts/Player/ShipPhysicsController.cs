using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPhysicsController : MonoBehaviour
{
    public Rigidbody2D shipPhysicsRB2D;
    public Transform shipGraphicsTransform;
    public Vector3 shipForward;
    public float thrustMagnitude;
    public int thrustKeyDownMult;

    void Start()
    {
        thrustKeyDownMult = 0;
        thrustMagnitude = 0.00025f;
    }

    // Update is called once per frame
    void Update()
    {
        shipForward = this.transform.up;
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
