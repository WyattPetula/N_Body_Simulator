using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipGraphicsController : MonoBehaviour
{
    public Transform shipPhysicsTransform;
    private float shipAngle;
    public float shipRotationMult;
    public float sizeMult = 5f;
    // Start is called before the first frame update
    void Start()
    {
        shipAngle = 0f;
        shipRotationMult = 3f;
    }

    // Update is called once per frame
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
