using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ctw_Player_behavior : MonoBehaviour
{
	Transform PlayerTransform;
	Rigidbody2D PlayerRigid2D;
	Collider2D PlayerCollider;
	
	public PhysicsMaterial2D Normal;
	public PhysicsMaterial2D Bouncy;
	
	Camera MainCamera;
	
	public bool DOWN = false;
	public int OnAttack = 0;
	public int HP = 3;
	
	int OnAir = 0;
	
	
    void Start(){
		
        PlayerTransform = GetComponent<Transform>();
		PlayerRigid2D = GetComponent<Rigidbody2D>();
		PlayerCollider = GetComponent<PolygonCollider2D>() as Collider2D;
		
		MainCamera = GameObject.Find("ctw_Main Camera").GetComponent<Camera>();
    }
	
	// Math
	
	float Math_2D_Force(float x, float y){ // Success
		
		return Mathf.Sqrt(Mathf.Pow(x,2)+Mathf.Pow(y,2));
	}
	
	// Timer
	
	void TimerAttackReset(){
		OnAttack = 0;
	}
	
	// Get
	
	Vector2 GetForceDirection(){ // Success
		
		Vector3 PlayerPos = PlayerTransform.position;
		Vector3 MouseStaticPos = new Vector3(MainCamera.ScreenToWorldPoint(Input.mousePosition).x,MainCamera.ScreenToWorldPoint(Input.mousePosition).y,0);
		Vector3 MousePrivatePos = MouseStaticPos - PlayerPos;
		
		float RangeKey = Math_2D_Force(MousePrivatePos.x,MousePrivatePos.y);
		
		MousePrivatePos = MousePrivatePos/RangeKey;
		
		Vector2 ForceDirection = new Vector2(MousePrivatePos.x,MousePrivatePos.y);
		
		return ForceDirection;
	}
	
	// Checks
	
	void Colliding(Collider2D other, int type){
		
	}
	
	// Actions
	
	void StrikeEnemy(){
		
	}
	
	void StrikeGround(){
		
	}
	
	void StrikePlatform(){
		
	}
	
	// Input
	
	void InputMove(){ // Success
		
		float XMoveCount = 0;
		
		if (OnAttack == 0){
				
			if (Input.GetKey(KeyCode.A))
				XMoveCount--;
			if (Input.GetKey(KeyCode.D))
				XMoveCount++;
			
			if (Mathf.Abs(PlayerRigid2D.velocity.x) < 15)
				PlayerRigid2D.velocity = new Vector2(PlayerRigid2D.velocity.x+1*XMoveCount,PlayerRigid2D.velocity.y);
			
			if (Input.GetKeyDown(KeyCode.S)){
				DOWN = true;
			}
			else{
				DOWN = false;
			}
			
			if ((Input.GetKeyDown(KeyCode.W)||Input.GetKeyDown(KeyCode.Space))&&(OnAir == 0)){
				PlayerRigid2D.velocity = PlayerRigid2D.velocity + new Vector2(0,40);
				OnAir = 1;
			}
		}
	}
	
	void InputAttack(){
		
		if ((Input.GetMouseButton(0))&&(OnAir == 1)&&(OnAttack != 2)){
			if ((PlayerRigid2D.angularVelocity <= 2000)&&(MainCamera.ScreenToWorldPoint(Input.mousePosition).x - PlayerTransform.position.x <= 0)){
				PlayerRigid2D.angularVelocity = PlayerRigid2D.angularVelocity + 30;
			}
			if ((PlayerRigid2D.angularVelocity >= -2000)&&(MainCamera.ScreenToWorldPoint(Input.mousePosition).x - PlayerTransform.position.x > 0)){
				PlayerRigid2D.angularVelocity = PlayerRigid2D.angularVelocity - 30;
			}
			OnAttack = 1;
		}
		else if ((Input.GetMouseButtonUp(0))&&(OnAttack == 1)){
			PlayerRigid2D.velocity = GetForceDirection()*Mathf.Abs(PlayerRigid2D.angularVelocity)/40;
			OnAttack = 2;
			PlayerCollider.sharedMaterial = Bouncy;
		}
		
		if (OnAttack == 1){
			PlayerRigid2D.angularDrag = 0.1f;
			PlayerRigid2D.drag = 2.5f;
			PlayerRigid2D.gravityScale = 0.5f;
		}
		
		else{
			PlayerRigid2D.angularDrag = 0.2f;
			PlayerRigid2D.drag = 0.2f;
			PlayerRigid2D.gravityScale = 9.8f;
		}
		
		if (OnAttack != 2)
			PlayerCollider.sharedMaterial = Normal;
	}
	
	// Running
	
	void OnTriggerStay2D(Collider2D other){ // Success
		
		switch (other.tag){
			case "Platform":
				ctw_Platform_behavior Script = other.GetComponent<ctw_Platform_behavior>();
				
				if ((Script.Trigger == false)&&(PlayerRigid2D.velocity.y <= 0)){
					OnAir = 0;
				}
			break;
			
			case "Enemy":
				
			break;
			
			case "Ground":
				OnAir = 0;
			break;
		}
	}
	
	void OnTriggerExit2D(Collider2D other){ // Success
		
		switch (other.tag){
			case "Platform":
				OnAir = 1;
			break;
			
			case "Ground":
				OnAir = 1;
			break;
		}
	}
	
	void OnCollisionEnter2D(Collision2D other){
		TimerAttackReset();
	}
	
    void Update()
    {
		InputAttack();
        InputMove();
    }
}
