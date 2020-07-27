using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_behavior : MonoBehaviour
{
    public Rigidbody2D force;
    public GameObject GameOverText;
    public GameObject Effect;

    Fuel_manage theFuel;

    void Start()
    {
        force = GetComponent<Rigidbody2D>();
        theFuel = FindObjectOfType<Fuel_manage>();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Space) && theFuel.IsFuel)
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
