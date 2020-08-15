using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ray : MonoBehaviour
{
    Color red = Color.red;
    Color yellow = Color.yellow;
    LineRenderer lineRenderer;
    Vector3 vec1;
    Vector3 vec2;
    Vector3 vec3;
    Vector3 vec4;
    public GameObject wallrenderer;
    public GameObject playerprefab;
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
        vec3 = transform.position;
        vec3.y = transform.position.y + 0.5f;
        vec4 = transform.position;
        vec4.y = transform.position.y - 0.5f;

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

            Debug.DrawRay(transform.position, transform.right * -17, yellow, 0.01f);
            Debug.DrawRay(vec3, transform.right * -17, yellow, 0.01f);
            Debug.DrawRay(vec4, transform.right * -17, yellow, 0.01f);

            RaycastHit2D hit1 = Physics2D.Raycast(transform.position, transform.right * -1, 17f);
            RaycastHit2D hit2 = Physics2D.Raycast(vec3, new Vector2(-1, 0), 17f);
            RaycastHit2D hit3 = Physics2D.Raycast(vec4, new Vector2(-1, 0), 17f);

            if(hit1.collider != null)
            {
                if(hit1.collider.gameObject.tag == "Player")
                {
                    Destroy(playerprefab);
                }
            }
            if(hit2.collider != null)
            {
                if(hit2.collider.gameObject.tag == "Player")
                {
                    Destroy(playerprefab);
                }
            }
            if(hit3.collider != null)
            {
                if(hit3.collider.gameObject.tag == "Player")
                {
                    Destroy(playerprefab);
                }
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