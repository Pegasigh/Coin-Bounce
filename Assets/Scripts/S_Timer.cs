using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class S_Timer : MonoBehaviour
{
    float startTime = 0;
    public TextMeshProUGUI timerText;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        //displaying time
        int minutes = (int)((Time.time - startTime)/60.0f);
        int seconds = (int)((Time.time - startTime)%60.0f);
        timerText.text = $"{minutes.ToString("00")}:{seconds.ToString("00")}";

        //updating best time if necessary
        float bt = PlayerPrefs.GetFloat("BestTime");
        if(bt < Time.time-startTime)
        {
            PlayerPrefs.SetFloat("BestTime", (Time.time - startTime));
        }
    }
}
