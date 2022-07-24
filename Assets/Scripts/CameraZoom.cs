using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]

public class CameraZoom : MonoBehaviour
{
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam.orthographicSize = (16.0f * Screen.height) / Screen.width;
    }
}
