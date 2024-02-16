using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public Camera mainCamera;
    public Transform shipPhysicsTransform;

    public float cameraZoomMult;
    public Vector3 offset;

    private void Start()
    {
        cameraZoomMult = -0.05f;
        mainCamera.orthographicSize = 5;
        offset = new Vector3(0, 0, -1);
    }
    void LateUpdate()
    {
        mainCamera.orthographicSize += Input.GetAxisRaw("Vertical") * cameraZoomMult * Time.deltaTime * 800;
        if (mainCamera.orthographicSize < 3)
            mainCamera.orthographicSize = 3;

        transform.position = shipPhysicsTransform.position + offset;
    }
}
