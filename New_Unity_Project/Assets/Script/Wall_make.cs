using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_make : MonoBehaviour
{
    public GameObject wallprefab;
    public float cur;
    public float max;
    float a;

    void Update()
    {
        Delay();
        Make();
    }

    void Delay()
    {
        cur += Time.deltaTime;
    }

    void Make()
    {
        if(cur > max)
        {
            a = Random.Range(0.0f, 4.0f);

            if(a >= 0.0f && a <= 1.0f)
            {
                Instantiate(wallprefab, new Vector2(13.3f, Random.Range(-2.5f, 2.5f)), Quaternion.Euler(0, 0, 0));
            }
            if(a > 1.0f && a <= 2.0f)
            {
                Instantiate(wallprefab, new Vector2(13.3f, Random.Range(-3.6f, 3.6f)), Quaternion.Euler(0, 0, 45));
            }
            if(a > 2.0f && a <= 3.0f)
            {
                Instantiate(wallprefab, new Vector2(13.3f, Random.Range(-3.6f, 3.6f)), Quaternion.Euler(0, 0, -45));
            }
            if(a > 3.0f && a <= 4.0f)
            {
                Instantiate(wallprefab, new Vector2(13.3f, Random.Range(-4.5f, 4.5f)), Quaternion.Euler(0, 0, 90));
            }
            cur = 0.0f;
        }
    }
}
