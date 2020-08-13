using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_behavior : MonoBehaviour
{
    Rigidbody2D rigid;
    float num;
    Score num0;
    public float speed;

    void Start()
    {
        num0 = GameObject.Find("ScoreText").GetComponent<Score>();
        rigid = GetComponent<Rigidbody2D>();
        num = Random.Range(0.0f, 10.0f);
        if(num0.ano > 10)
        {
            speed = num0.ano / 10 + 10;
        }
        else
        {
            speed = 10f;
        }
    }

    void FixedUpdate()
    {
        if(num >= 0.0f && num <= 1.0f)
        {
            rigid.rotation += 3.0f;
        }
        rigid.velocity = new Vector2(-1, 0) * speed;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Left")
        {
            Destroy(gameObject);
        }
    }
}