using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Paddle : MonoBehaviour
{
    public Camera cam;
    public PhysicsBody body;
    public float xMin;
    public float xMax;

    void Start()
    {
        //setting initial position near bottom of screen
        Vector3 pos = new Vector3(0.0f, (-cam.orthographicSize * 0.9f), 0.0f);
        transform.position = pos;
    }

    void FixedUpdate()
    {
        //follow mouse on x axis
        if (body)
        {
            //clamp position within level borders
            float moveToPosX = Mathf.Clamp(cam.ScreenToWorldPoint(Input.mousePosition).x, xMin, xMax);

            //body.MovePosition(cam.ScreenToWorldPoint(Input.mousePosition));
            body.vel.x = (moveToPosX - body.transform.position.x) / Time.fixedDeltaTime;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(new Vector3(xMin, -100, 0), new Vector3(xMin, 100, 0));
        Gizmos.DrawLine(new Vector3(xMax, -100, 0), new Vector3(xMax, 100, 0));
    }
}
