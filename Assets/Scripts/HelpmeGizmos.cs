using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpmeGizmos : MonoBehaviour
{
    public GameObject box, circle;

    private void OnDrawGizmos()
    {
        var b = box.GetComponent<BoxCollider>();
        var c = circle.GetComponent<CircleCollider>();

        Vector2 displacement = (c.GetComponent<PhysicsBody>().vel - b.GetComponent<PhysicsBody>().vel);
        Gizmos.color = Color.green;
        if (PhysicsEngine.GetCollisionInfo(b.transform.position, new Vector2(b.halfWidth, b.halfHeight), c.transform.position, c.radius, displacement, out var norm))
            Gizmos.color = Color.green;
        else
            Gizmos.color = Color.red;
        Gizmos.DrawLine(c.transform.position, c.transform.position + (Vector3)norm);
        Gizmos.DrawSphere(norm, 0.1f);
    }
}
