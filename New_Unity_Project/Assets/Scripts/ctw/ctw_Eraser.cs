using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ctw_Eraser : MonoBehaviour
{
	public float Alpha;
	
	SpriteRenderer SelfSprite;
	Transform SelfTransform;
	CircleCollider2D SelfCollider;
	
	Transform PlayerTransform;
	
    // Start is called before the first frame update
    void Start()
    {
		Alpha = 0f;
		
        SelfSprite = GetComponent<SpriteRenderer>();
		SelfTransform = GetComponent<Transform>();
		SelfCollider = GetComponent<CircleCollider2D>() as CircleCollider2D;
		
		PlayerTransform = GameObject.Find("ctw_Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        SelfTransform.position = PlayerTransform.position;
		
		if (Alpha > 0f){
			Alpha -= 0.05f;
		}
		
		if (Alpha <= 0f){
			Alpha = 0f;
		}
		
		SelfSprite.color = new Color(1,1,1,Alpha);
		SelfTransform.localScale = new Vector2( (2f - 2f*Alpha) , (2f - 2f*Alpha) );
		SelfCollider.radius = 2.34f*(2f - 2f*Alpha);
    }
}
