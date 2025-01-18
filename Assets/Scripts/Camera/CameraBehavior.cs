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
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            cameraZoomMult = -0.05f;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            cameraZoomMult = -0.15f;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            cameraZoomMult = -1f;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            cameraZoomMult = -2f;
        }
    }
    void LateUpdate()
    {
        if(Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0){
            mainCamera.orthographicSize += Input.GetAxisRaw("Vertical") * cameraZoomMult * Time.deltaTime * 800;
        }
        else{
            mainCamera.orthographicSize += Input.mouseScrollDelta.y * (cameraZoomMult * 10) * Time.deltaTime * 800;
        }
        if (mainCamera.orthographicSize < 3)
            mainCamera.orthographicSize = 3;

        transform.position = shipPhysicsTransform.position + offset;
    }
}
