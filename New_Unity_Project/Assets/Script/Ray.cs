using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ray : MonoBehaviour
{
    Color red = Color.red;
    Color yellow = Color.yellow;
    RaycastHit hit;
    LineRenderer lineRenderer;
    Vector3 vec1;
    Vector3 vec2;
    public GameObject wallrenderer;
    float cur;
    public float num1;
    public float num2;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
	    lineRenderer.SetColors(red, red);
    }

    void Update()
    {
        if(GameObject.FindWithTag("wallrenderer"))
        {
            cur = 0.0f;
        }

        Delay();

        vec1 = new Vector3(8.0f, transform.position.y, 0);
        vec2 = new Vector3(13.0f, transform.position.y, 0);

        Behaviour();
    }

    void Delay()
    {
        cur += Time.deltaTime;
    }

    void Behaviour()
    {
        if(cur > 0.1f && cur <= 0.2f)
        {
            transform.position = new Vector3(13.0f, Random.Range(num1, num2), 0);
        }
        else if(cur > 0.2f && cur <= 4.0f)
        {
            transform.position = Vector3.MoveTowards(transform.position, vec1, 0.07f);
        }
        else if(cur > 4.0f && cur <= 7.0f)
        {
            lineRenderer.SetWidth(1.0f, 1.0f);
            Debug.DrawRay(transform.position, transform.right * -50, yellow, 0.01f);

            if(Physics.Raycast(transform.position, -transform.right, out hit, 50))
            {
                hit.transform.GetComponent<SpriteRenderer>().color = red;
            }
        }
        else if(cur > 7.0f && cur <= 8.0f)
        {
            lineRenderer.SetWidth(0.0f, 0.0f);
        }
        else if(cur > 8.0f && cur <= 10.0f)
        {
            transform.position = Vector3.MoveTowards(transform.position, vec2, 0.07f);
        }
        else if(cur > 10.0f)
        {
            wallrenderer.SetActive(true);
        }
    }
}