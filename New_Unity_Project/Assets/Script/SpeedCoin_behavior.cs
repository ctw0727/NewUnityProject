using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedCoin_behavior : MonoBehaviour
{
    float Yspeed = 4f;
    float length = 3.5f;
    float runningTime = 0f;
    float Ypos = 0f;
    float Xspeed = 4f;
    Vector2 curXpos;
    Vector2 nextXpos;
    Vector2 Xpos;

    void Update()
    {
        runningTime += Time.deltaTime * Yspeed;
        Ypos = Mathf.Sin(runningTime) * length;

        curXpos.x = transform.position.x;
        nextXpos.x = -1 * Xspeed * Time.deltaTime;
        Xpos.x = curXpos.x + nextXpos.x;

        transform.position = new Vector2(Xpos.x, Ypos);
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
