using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_GameOverButtons : MonoBehaviour
{
    private void OnEnable()
    {
        Cursor.visible = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene("L_Game");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("L_MainMenu");
    }
}
