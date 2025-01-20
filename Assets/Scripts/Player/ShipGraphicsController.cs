using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipGraphicsController : MonoBehaviour
{
    public Transform shipPhysicsTransform;
    private float shipAngle;
    public float shipRotationMult;
    public float sizeMult = 5f;

    void Start()
    {
        shipAngle = 0f;
        shipRotationMult = 3f;
    }
    void Update()
    {
        gameObject.transform.position = shipPhysicsTransform.position;
        shipAngle = -1 * Input.GetAxisRaw("Horizontal") * shipRotationMult;
    }

    private void FixedUpdate()
    {
        gameObject.transform.Rotate(0, 0, shipAngle);
    }
}
