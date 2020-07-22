using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_make : MonoBehaviour
{
    public GameObject bulletprefab;
    public float cur;
    public float max;
    public float curPos;
    public Transform Target;

    void Start()
    {
        curPos = 0.5f;
    }

    void Update()
    {
        Move();
        Delay();
        Make();
        
    }

    public void Delay()
    {
        cur += Time.deltaTime;
    }

    void Make()
    {
        if(cur > max)
        {
            Instantiate(bulletprefab, new Vector2(13.3f, transform.position.y), Quaternion.Euler(0, 0, 0));
            cur = 0.0f;
        }
    }

    public void Move()
    {
        if(Target != null)
        {
            Vector3 curPosition = Vector3.Lerp(transform.position, Target.position, curPos);

            transform.position = curPosition;
        }
    }
}
