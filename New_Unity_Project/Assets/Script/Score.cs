using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    float score;

    void Update()
    {
        score += Time.deltaTime;
        scoreText.text = score.ToString("N0") + "M";

        if(!GameObject.FindWithTag("Player"))
        {
            score -= Time.deltaTime;
        }
    }
}
