using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ctw_Bullet_behavior : MonoBehaviour
{
	Transform BulletTransform;
	Collider2D BulletCollider;
	Rigidbody2D BulletRigid2D;
	SpriteRenderer BulletSprite;
	
	public Sprite spriteBullet;
	public Sprite spriteEffect;
	
	public bool OnWork = true;
	public Vector3 Vel = new Vector3(0,0,0);
	
	public bool Pop;
	float Alpha = 1f;
	
	void Start(){
		
		Pop = false;
		BulletTransform = GetComponent<Transform>();
        BulletCollider = GetComponent<BoxCollider2D>() as Collider2D;
		BulletRigid2D = GetComponent<Rigidbody2D>();
		BulletSprite = GetComponent<SpriteRenderer>();
    }
	
	void StrikeWall(){
		
		Alpha = 1f;
		OnWork = false;
		Pop = false;
	}

	void OnTriggerStay2D(Collider2D other){
		if ((other.tag == "Wall")||(other.tag == "Ground")){
			StrikeWall();
		}
		if ((other.tag == "Eraser")&&(other.GetComponent<ctw_Eraser_behavior>().Alpha > 0.01f)){
			Alpha = 1f;
			OnWork = false;
		}
	}
	
	void Rendering(){
		
		float R = BulletSprite.color.r;
		float G = BulletSprite.color.g;
		float B = BulletSprite.color.b;
		
		switch(OnWork) {
			
			case true:
				Alpha = 1f;
				
				BulletSprite.sprite = spriteBullet;
				BulletSprite.color = new Color(R, G, B, 1f);
				BulletRigid2D.velocity = Vel;
				BulletTransform.localScale = new Vector2(1f , 0.5f);
			break;
			
			case false:
				BulletRigid2D.velocity = new Vector3(0,0,0);
				if (Pop == true){
					
					if (Alpha > 0f){
						Alpha -= 0.05f;
					}
					
					if (Alpha <= 0f){
						Alpha = 0f;
					}
					
					BulletSprite.sprite = spriteEffect;
					BulletSprite.color = new Color(R, G, B, Alpha);
					BulletTransform.localScale = new Vector2( (0.5f - 0.5f*Alpha), (0.5f - 0.5f*Alpha) );
				}
				else{
					
					BulletSprite.color = new Color(R, G, B, 0f);
					BulletTransform.localScale = new Vector2( (0.5f - 0.5f*Alpha), (0.5f - 0.5f*Alpha) );
				}
			break;
		}
	}
	
    void Update(){
		
        Rendering();
    }
}
