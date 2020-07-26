using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_behavior : MonoBehaviour
{
    Rigidbody2D rigid;
    float num;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        num = Random.Range(0.0f, 10.0f);
    }

    void Update()
    {
        if(num >= 0.0f && num <= 1.0f)
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