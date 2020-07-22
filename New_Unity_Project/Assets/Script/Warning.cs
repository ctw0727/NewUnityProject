using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning : MonoBehaviour
{
    SpriteRenderer G;
    public float curPos;
    public Transform Target;
    float a;
    Vector3 curPosition;

    void Start()
    {
        curPos = 0.5f;
        G = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Move();
        Warn();
    }

    void Warn()
    {
        a += Time.deltaTime;

        if(a >= 3.0f)
        {
            G.color = new Vector4(1.0f, 0.0f, 0.0f, 1.0f);
        }
        if(a >= 5.0f)
        {
            G.color = new Vector4(1.0f, 0.0f, 0.0f, 0.0f);
            a = 0.0f;
        }
    }

    void Move()
    {
        if(Target != null)
        {
            curPosition = Vector3.Lerp(transform.position, Target.position + Target.right*16, curPos);

            transform.position = curPosition;
        }
    }
}
