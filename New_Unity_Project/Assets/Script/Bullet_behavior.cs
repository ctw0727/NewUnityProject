using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_behavior : MonoBehaviour
{
    Rigidbody2D rig;
    
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rig.velocity = new Vector2(-20, 0);
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
