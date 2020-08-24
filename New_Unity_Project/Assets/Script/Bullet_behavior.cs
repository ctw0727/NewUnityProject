using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_behavior : MonoBehaviour
{
    Rigidbody2D rig;
    Score num0;
    public float speed;
    
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        num0 = GameObject.Find("ScoreText").GetComponent<Score>();

        if(num0.ano > 10)
        {
            speed = num0.ano / 10 + 20;
        }
        else
        {
            speed = 20f;
        }
    }

    void FixedUpdate()
    {
        rig.velocity = new Vector2(-1, 0) * speed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Left")
        {
            Destroy(gameObject);
        }
    }
}
