using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCollider : MonoBehaviour
{
    public float halfWidth;
    public float halfHeight;

    private void OnDrawGizmos()
    {
        Vector2 cornerTL = new Vector2(transform.position.x - halfWidth, transform.position.y + halfHeight);
        Vector2 cornerTR = new Vector2(transform.position.x + halfWidth, transform.position.y + halfHeight);
        Vector2 cornerBL = new Vector2(transform.position.x - halfWidth, transform.position.y - halfHeight);
        Vector2 cornerBR = new Vector2(transform.position.x + halfWidth, transform.position.y - halfHeight);

        Gizmos.color = Color.red;

        Gizmos.DrawLine(cornerTL, cornerTR);
        Gizmos.DrawLine(cornerTR, cornerBR);
        Gizmos.DrawLine(cornerBR, cornerBL);
        Gizmos.DrawLine(cornerBL, cornerTL);
    }
}
