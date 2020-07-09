using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ctw_Eraser_behavior : MonoBehaviour
{
	public float Alpha;
	
	SpriteRenderer SelfSprite;
	Transform SelfTransform;
	CircleCollider2D SelfCollider;
	
	Transform PlayerTransform;
	Transform BossTransform;
	
	ctw_Boss_behavior BossScript;
	
    void Start(){
		
		Alpha = 0f;
		
        SelfSprite = GetComponent<SpriteRenderer>();
		SelfTransform = GetComponent<Transform>();
		SelfCollider = GetComponent<CircleCollider2D>() as CircleCollider2D;
		
		PlayerTransform = GameObject.Find("ctw_Player").GetComponent<Transform>();
		BossTransform = GameObject.Find("ctw_Boss").GetComponent<Transform>();
		
		BossScript = GameObject.Find("ctw_Boss").GetComponent<ctw_Boss_behavior>();
    }

	
    void Update(){
		
		if (SelfTransform.name == "ctw_Eraser_Player"){
			
			if (Alpha > 0f){
				Alpha -= 0.05f;
			}
		
			if (Alpha <= 0f){
				Alpha = 0f;
			}
			
			SelfTransform.position = PlayerTransform.position;
			SelfSprite.color = new Color(1,1,1,Alpha);
			SelfTransform.localScale = new Vector2( (2f - 2f*Alpha) , (2f - 2f*Alpha) );
			SelfCollider.radius = 2.34f*(2f - 2f*Alpha);
		}
		
		else {
			
			if (Alpha > 0f){
				Alpha -= 0.005f;
				if (BossScript.DEAD != 1) Alpha -= 0.015f;
			}
		
			if (Alpha <= 0f){
				Alpha = 0f;
			}
			
			SelfTransform.position = BossTransform.position;
			SelfSprite.color = new Color(1,0.8f,0.8f,Alpha);
			SelfTransform.localScale = new Vector2( (50f - 50f*Alpha) , (50f - 50f*Alpha) );
			SelfCollider.radius = 2.34f*(50f - 50f*Alpha);
		}
    }
}
