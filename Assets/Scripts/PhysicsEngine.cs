using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class PhysicsEngine : MonoBehaviour
{
    Vector2 g = new Vector2(0.0f, -9.81f);
    PhysicsBody[] defaults;

    private void Start()
    {
        PhysicsBody[] bodies = FindObjectsOfType<PhysicsBody>();
        //grabbing default layer bodies only
        defaults = bodies.Where(b => b.gameObject.layer == LayerMask.NameToLayer("Default")).ToArray();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PhysicsBody[] bodies = FindObjectsOfType<PhysicsBody>();
        //grabbing drops layer bodies only
        PhysicsBody[] drops = bodies.Where(b => b.gameObject.layer == LayerMask.NameToLayer("Drops")).ToArray();


        foreach(PhysicsBody b in drops)
        {
            //applying gravity
            b.vel += g * Time.fixedDeltaTime;

            //collision detection
            foreach(PhysicsBody d in defaults)
            {
                Collision(d, b);
            }
        }
        foreach(PhysicsBody b in bodies)
        {
            b.transform.position += (Vector3)(b.vel) * Time.fixedDeltaTime;
        }
    }

    void Collision(PhysicsBody def, PhysicsBody drop)
    {
        BoxCollider box = def.GetComponent<BoxCollider>();
        CircleCollider circle = drop.GetComponent<CircleCollider>();
        Vector2 relativeVel = def.vel - drop.vel;

        if (GetCollisionInfo(box.transform.position, new Vector2(box.halfWidth, box.halfHeight), circle.transform.position, circle.radius, relativeVel * -Time.fixedDeltaTime, out Vector2 collisionNormal))
        {
            //|N|
            Vector2 nNorm = collisionNormal.normalized;
            //projection vector
            Vector2 p = (Mathf.Max(Vector2.Dot(-drop.vel, nNorm), 0) * nNorm);
            {
                //friction
                float friction = (def.friction + drop.friction) / 2;
                Vector2 frictionDir = new Vector2(nNorm.y * -1, nNorm.x);
                Vector2 frictionVec = (Vector2.Dot(relativeVel, frictionDir) * frictionDir);

                //applying friction to drop
                drop.vel += frictionVec * friction * Time.fixedDeltaTime;
            }
            //final velocity
            drop.vel = drop.vel + ((1 + drop.bounciness) * p);

            if (drop.GetComponent<S_Bomb>())
            {
                drop.GetComponent<S_Bomb>().OnCollision(def);
            }
            if (drop.GetComponent<S_Coin>())
            {
                drop.GetComponent<S_Coin>().OnCollision(def);
            }
        }
    }

    //MARTENS CODE STARTS HERE
    public static bool GetCollisionInfo(Vector2 boxCenter, Vector2 boxHalfSize, Vector2 circleCenter, float circleRadius, Vector2 circleDisplacement, out Vector2 collisionNorm)
    {
        float l = boxCenter.x - boxHalfSize.x;
        float r = boxCenter.x + boxHalfSize.x;
        float b = boxCenter.y - boxHalfSize.y;
        float t = boxCenter.y + boxHalfSize.y;
        Vector2 closestPoint = new Vector2(Mathf.Clamp(circleCenter.x, l, r), Mathf.Clamp(circleCenter.y, b, t));

        collisionNorm = circleCenter - closestPoint;

        return collisionNorm.magnitude < (circleDisplacement.magnitude + circleRadius);
    }
    //MARTENS CODE ENDS HERE
}
