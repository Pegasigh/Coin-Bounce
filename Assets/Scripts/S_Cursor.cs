using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Cursor : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = false;
    }
    private void OnDestroy()
    {
        Cursor.visible = true;
    }
}
