using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSpawner : MonoBehaviour
{
    //prefabs
    public GameObject bomb;
    public GameObject coin;

    public Camera cam;
    public GameObject pauseMenu;

    public float minBPS;
    public float maxBPS;
    public float minCPS;
    public float maxCPS;

    float startTime;
    float timer;
    float lastBomb;
    float lastCoin = -10.0f;

    private void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        timer = Time.time - startTime;

        //bombs
        float BPS = Mathf.Lerp(minBPS, maxBPS, GetDifficulty());
        float bombDelay = 1 / BPS;
        if(lastBomb + bombDelay <= timer)
        {
            //spawn bomb
            Instantiate(bomb, new Vector3(Random.Range(-9.0f, 9.0f), cam.orthographicSize + 0.5f, 0.0f), Quaternion.identity);
            lastBomb = timer;
        }

        //coins
        float CPS = Mathf.Lerp(minCPS, maxCPS, GetDifficulty());
        float coinDelay = 1 / CPS;
        if(lastCoin + coinDelay <= timer)
        {
            //spawn coin
            Instantiate(coin, new Vector3(Random.Range(-9.0f, 9.0f), cam.orthographicSize + 0.5f, 0.0f), Quaternion.identity);
            lastCoin = timer;
        }

        //pauses game
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
        }
    }

    float GetDifficulty()
    {
        float difficulty = Mathf.Min(Mathf.Pow(1.1f, (timer)/6.2f), 100)/100;
        return difficulty;
    }
}
