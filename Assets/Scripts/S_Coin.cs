using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Coin : MonoBehaviour
{
    int bounces = 0;
    public int maxBounces;
    public AudioSource sound;

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    S_Score score = collision.gameObject.GetComponent<S_Score>();

    //    if (score)
    //    {
    //        bounces++;
    //        score.score++;
    //        sound.Play();

    //        if (bounces == maxBounces)
    //        {
    //            Destroy(gameObject.GetComponent<SpriteRenderer>());
    //            Destroy(gameObject.GetComponent<CircleCollider2D>());
    //            Destroy(gameObject.GetComponent<Rigidbody2D>());
    //        }
    //    }
    //}
    public void OnCollision(PhysicsBody otherBody)
    {
        S_Score score = otherBody.gameObject.GetComponent<S_Score>();

        if (score)
        {
            bounces++;
            score.score++;
            sound.Play();

            if (bounces == maxBounces)
            {
                Destroy(gameObject.GetComponent<SpriteRenderer>());
                Destroy(gameObject.GetComponent<CircleCollider>());
                Destroy(gameObject.GetComponent<PhysicsBody>());
            }
        }
    }
}
