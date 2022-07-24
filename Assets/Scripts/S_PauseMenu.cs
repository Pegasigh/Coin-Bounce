using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_PauseMenu : MonoBehaviour
{
    private void OnEnable()
    {
        Time.timeScale = 0.0f; //pauses time
        Cursor.visible = true;
    }
    private void OnDisable()
    {
        Time.timeScale = 1.0f; //resumes time
        Cursor.visible = false;
    }

    //buttons
    public void MainMenu()
    {
        SceneManager.LoadScene("L_MainMenu");
    }
}
