using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_make : MonoBehaviour
{
    public GameObject wallprefab;
    public float cur;
    public float max;
    float num;

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
            num = Random.Range(0.0f, 4.0f);

            if(num >= 0.0f && num <= 1.0f)
            {
                Instantiate(wallprefab, new Vector2(13.3f, Random.Range(-2.0f, 2.5f)), Quaternion.Euler(0, 0, 0));
            }
            else if(num > 1.0f && num <= 2.0f)
            {
                Instantiate(wallprefab, new Vector2(13.3f, Random.Range(-3.1f, 3.6f)), Quaternion.Euler(0, 0, 45));
            }
            else if(num > 2.0f && num <= 3.0f)
            {
                Instantiate(wallprefab, new Vector2(13.3f, Random.Range(-3.1f, 3.6f)), Quaternion.Euler(0, 0, -45));
            }
            else if(num > 3.0f && num <= 4.0f)
            {
                Instantiate(wallprefab, new Vector2(13.3f, Random.Range(-4.0f, 4.5f)), Quaternion.Euler(0, 0, 90));
            }
            cur = 0.0f;
        }
    }
}
