using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Bomb : MonoBehaviour
{
    public AudioSource sound;

    //public void OnCollisionEnter2D(Collision2D collision)
    //{
    //    //checks if colliding with something that has health
    //    S_Health health = collision.gameObject.GetComponent<S_Health>();
    //    if (health)
    //    {
    //        health.health--;
    //        sound.Play();

    //        gameObject.GetComponent<Animator>().SetBool("Exploded", true);
    //        Destroy(gameObject.GetComponent<CircleCollider2D>());
    //        Destroy(gameObject.GetComponent<Rigidbody2D>());
    //    }
    //}
    public void OnCollision(PhysicsBody otherBody)
    {
        S_Health health = otherBody.gameObject.GetComponent<S_Health>();
        if(health)
        {
            health.health--;
            sound.Play();

            gameObject.GetComponent<Animator>().SetBool("Exploded", true);
            Destroy(gameObject.GetComponent<CircleCollider>());
            Destroy(gameObject.GetComponent<PhysicsBody>());
        }
    }

    public void BombDestroy()
    {
        Destroy(gameObject);
    }
}
