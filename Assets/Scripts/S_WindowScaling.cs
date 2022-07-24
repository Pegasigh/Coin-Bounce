using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_WindowScaling : MonoBehaviour
{
    private int lastWidth;
    private int lastHeight;

    // Start is called before the first frame update
    void Start()
    {
        lastHeight = Screen.height;
        lastWidth = Screen.width;
    }

    // Update is called once per frame
    void Update()
    {
        if(Screen.width != lastWidth)
        {
            //set height
            Screen.SetResolution(Screen.width, (int)(Screen.width * (9.0f / 16.0f)), false);
            lastHeight = Screen.height;
            lastWidth = Screen.width;
        }
        if(Screen.height != lastHeight)
        {
            //set width
            Screen.SetResolution((int)(Screen.height * (16.0f / 9.0f)), Screen.height, false);
            lastHeight = Screen.height;
            lastWidth = Screen.width;
        }
    }
}
