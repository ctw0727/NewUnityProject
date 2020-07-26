using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_behavior : MonoBehaviour
{
    Rigidbody2D force;
    public GameObject GameOverText;
    public GameObject Effect;

    void Start()
    {
        force = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            force.AddForce(Vector2.up * 1, ForceMode2D.Impulse);
            Effect.SetActive(true);
        }
        else
        {
            Effect.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "wall" || collision.gameObject.tag == "bullet")
        {
            Destroy(gameObject);
            GameOver();
        }
    }

    void GameOver()
    {
        GameOverText.SetActive(true);
    }
}
