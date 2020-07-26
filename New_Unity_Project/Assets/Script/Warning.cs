using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning : MonoBehaviour
{
    SpriteRenderer red;
    float num;

    void Start()
    {
        red = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Warn();
    }

    void Warn()
    {
        num += Time.deltaTime;

        if(num >= 3.0f)
        {
            red.color = new Vector4(1.0f, 0.0f, 0.0f, 1.0f);
        }
        if(num >= 5.0f)
        {
            red.color = new Vector4(1.0f, 0.0f, 0.0f, 0.0f);
            num = 0.0f;
        }
    }
}
