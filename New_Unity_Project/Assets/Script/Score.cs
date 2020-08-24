using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    float score;
    public int ano;
    public float bno;
    public GameObject wallrenderer;
    public GameObject GameOverText;
    
    void Update()
    { 
        score += Time.deltaTime;
        bno += Time.deltaTime;
        ano = Mathf.RoundToInt(bno);
        scoreText.text = score.ToString("N0") + "M";

        if(ano % 30 == 0 && ano > 0)
        {
            wallrenderer.SetActive(false);
        }

        if(!GameObject.FindWithTag("Player"))
        {
            score -= Time.deltaTime;
            GameOverText.SetActive(true);
        }
    }
}
