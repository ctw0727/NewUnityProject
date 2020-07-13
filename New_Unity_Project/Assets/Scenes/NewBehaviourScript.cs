using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    Transform PlayerTransform;
    Rigidbody2D Player Rigid2D;

    void Start()
    {
        PlayerTransform = GetComponent<Transform>();
        PlayerRigid2D = GetComponent<Rigidbody2D>();
    }

    void Move()
    {
        float XMoveCount = 0;
        float YMoveCount = 0;

        if(Input.Getkey(KeyCode.A))
        {
            XMoveCount--;
        }
        if(Input.Getkey(KeyCode.D))
        {
            XMoveCount++;
        }
        if(Input.Getkey(KeyCode.W))
        {
            YMoveCount++;
        }
        if(Input.Getkey(KeyCode.S))
        {
            YMoveCount--;
        }

        PlayerRigid2D.velocity = new Vector2(20*XMoveCount, 20*YMoveCount);
    }
    void Update()
    {
        Move();
    }
}
