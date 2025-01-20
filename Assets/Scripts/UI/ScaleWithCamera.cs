using System.Collections;
using UnityEngine;

public class ScaleWithCamera : MonoBehaviour
{
    public Camera mainCamera;
    public float sizeMult = 5;
    public float xOffset = 0;
    public float yOffset = 0;

    void Update()
    {
        gameObject.transform.localScale = new Vector3(mainCamera.orthographicSize / (sizeMult + xOffset), mainCamera.orthographicSize / (sizeMult + yOffset), 0);
    }
}
