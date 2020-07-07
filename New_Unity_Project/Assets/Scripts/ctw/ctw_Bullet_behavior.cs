using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ctw_Bullet_behavior : MonoBehaviour
{
	Collider2D BulletCollider;
	Rigidbody2D BulletRigid2D;
	SpriteRenderer BulletSprite;
	
	public bool OnWork = true;
	public Vector3 Vel = new Vector3(0,0,0);
	
	void Start(){
		
        BulletCollider = GetComponent<CapsuleCollider2D>() as Collider2D;
		BulletRigid2D = GetComponent<Rigidbody2D>();
		BulletSprite = GetComponent<SpriteRenderer>();
    }
	
	void StrikeWall(){
		
		OnWork = false;
	}

	void OnTriggerEnter2D(Collider2D other){
		if ((other.tag == "Wall")||(other.tag == "Ground")){
			StrikeWall();
		}
	}
	
	void Rendering(){
		
		float R = BulletSprite.color.r;
		float G = BulletSprite.color.g;
		float B = BulletSprite.color.b;
		
		switch(OnWork) {
			
			case true:
				BulletSprite.color = new Color(R, G, B, 1f);
				BulletRigid2D.velocity = Vel;
			break;
			
			case false:
				BulletSprite.color = new Color(R, G, B, 0f);
				BulletRigid2D.velocity = new Vector3(0,0,0);
			break;
		}
	}
	
    void Update(){
		
        Rendering();
    }
}
