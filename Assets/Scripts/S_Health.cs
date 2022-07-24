using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Health : MonoBehaviour
{
    int health_ = 3;
    public GameObject[] hearts;
    public GameObject GameOver;

    public int health
    {
        get { return health_; }
        set
        {
            health_ = value;
            if(health_<3)
            {
                hearts[2].GetComponent<Animator>().SetBool("Destroyed", true);
            }
            if(health_<2)
            {
                hearts[1].GetComponent<Animator>().SetBool("Destroyed", true);
            }


            //DEATH
            if(health_<1)
            {
                hearts[0].GetComponent<Animator>().SetBool("Destroyed", true);

                //deleting all rigidbodies
                Rigidbody2D[] objects = GameObject.FindObjectsOfType<Rigidbody2D>();
                for(int i = 0; i < objects.Length; i++)
                {
                    Destroy(objects[i]);
                }
                //delete timer
                Destroy(FindObjectOfType<S_Timer>());
                //delete spawner
                Destroy(FindObjectOfType<DropSpawner>());

                //game over ui
                GameOver.SetActive(true);
            }
        }
    }
}
