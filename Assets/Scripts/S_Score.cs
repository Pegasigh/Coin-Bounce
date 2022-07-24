using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class S_Score : MonoBehaviour
{
    int score_;
    public TextMeshProUGUI scoreText;

    public int score
    {
        get { return score_; }
        set 
        { 
            score_ = value;
            scoreText.text = score_.ToString("0000");

            //updating high score if needed
            int hs = PlayerPrefs.GetInt("HighScore");
            if(score_ > hs)
            {
                PlayerPrefs.SetInt("HighScore", score_);
            }
        }
    }
}
