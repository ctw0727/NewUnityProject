using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedCoin_make : MonoBehaviour
{
    Score num0;
    float num;
    public int max;
    public GameObject speedcoinprefab;

    void Start()
    {
        num0 = GameObject.Find("ScoreText").GetComponent<Score>();
    }

    void Update()
    {
        if(num0.ano >= max)
        {
            num += Time.deltaTime;

            if(num >= 15f)
            {
                Instantiate(speedcoinprefab, new Vector2(Random.Range(9.5f, 15.5f), 0), Quaternion.Euler(0, 0, 0));
                num = 0f;
            }
        }
    }
}
