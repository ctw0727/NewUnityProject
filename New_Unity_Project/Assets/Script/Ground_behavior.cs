using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground_behavior : MonoBehaviour
{
    public float speed;
    public int startIndex;
    public int endIndex;
    public Transform[] sprites;
    Score num0;

    void Start()
    {
        num0 = GameObject.Find("ScoreText").GetComponent<Score>();
    }

    void Update()
    {
        if(num0.ano > 10)
        {
            speed = num0.ano / 10 + 10;
        }
        else
        {
            speed = 10f;
        }
        
        Vector3 curpos = transform.position;
        Vector3 nextpos = Vector3.left * speed * Time.deltaTime;
        transform.position = curpos + nextpos;

        if(sprites[endIndex].position.x < -18)
        {
            Vector3 backSpritePos = sprites[startIndex].localPosition;
            Vector3 frontSpritePos = sprites[endIndex].localPosition;
            sprites[endIndex].transform.localPosition = backSpritePos + Vector3.right * 18;

            int startIndexSave = startIndex;
            startIndex = endIndex;
            endIndex = (startIndexSave - 1 == -1) ? sprites.Length - 1 : startIndexSave - 1;
        }
    }
}
