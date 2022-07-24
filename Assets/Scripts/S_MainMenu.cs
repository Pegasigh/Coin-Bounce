using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class S_MainMenu : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI time;

    private void Start()
    {
        //cursor
        Cursor.visible = true;

        //displaying score
        score.text = PlayerPrefs.GetInt("HighScore").ToString();

        //displaying time
        int minutes = (int)(PlayerPrefs.GetFloat("BestTime") / 60.0f);
        int seconds = (int)(PlayerPrefs.GetFloat("BestTime") % 60.0f);
        time.text = $"{minutes.ToString("00")}:{seconds.ToString("00")}";
    }
    public void Play()
    {
        SceneManager.LoadScene("L_Game");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
