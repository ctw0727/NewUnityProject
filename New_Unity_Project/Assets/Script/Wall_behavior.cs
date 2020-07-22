using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_behavior : MonoBehaviour
{
    Rigidbody2D rigid;
    float b;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        b = Random.Range(0.0f, 10.0f);
    }

    void Update()
    {
        if(b >= 0.0f && b <= 1.0f)
        {
            rigid.rotation += 1.0f;
        }
        rigid.velocity = new Vector2(-10, 0);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Left")
        {
            Destroy(gameObject);
        }
    }
}