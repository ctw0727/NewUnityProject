using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ctw_Boss_behavior : MonoBehaviour
{
	public float DamageForce;
	public float MaxHP;
	public float HP;
	public float LastHP;
	public int Invincible = 0;
	public int DEAD = 0;
	
	public GameObject BulletPrefab;
	
	Transform PlayerTransform;
	Rigidbody2D PlayerRigid2D;
	ctw_Player_behavior PlayerScript;
	
	ctw_Camera_behavior CameraScript;
	
	Transform BossTransform;
	SpriteRenderer BossSprite;
	ctw_Eraser_behavior Eraser;
	
	GameObject[] Bullet = new GameObject[250];
	
	int BulletPool = 0;
	int ATTACK = 0;
	int AttackType = 0;
	
	
	int Time = 0;
	
	float AlphaInvincible = 0;
	
    void Start(){
		
        MaxHP = 10000;
		HP = 10000;
		LastHP = 10000;
		
		PlayerTransform = GameObject.Find("ctw_Player").GetComponent<Transform>();
		PlayerRigid2D = GameObject.Find("ctw_Player").GetComponent<Rigidbody2D>();
		PlayerScript = GameObject.Find("ctw_Player").GetComponent<ctw_Player_behavior>();
		
		CameraScript = GameObject.Find("ctw_Main Camera").GetComponent<ctw_Camera_behavior>();
		
		BossTransform = GetComponent<Transform>();
		BossSprite = GetComponent<SpriteRenderer>();
		Eraser = GameObject.Find("ctw_Eraser_Boss").GetComponent<ctw_Eraser_behavior>();
		
		InvokeRepeating("Timer_ticker",1f,1f);
    }
	
	// Timers
	
	void Timer_ticker(){
		
		Time++;
	}
	
	void Timer_InvincibleCool(){
		
		Invincible = 0;
	}
	
	void Timer_AttackCool(){
		
		ATTACK = 0;
	}
	
	// Maths
	
	float Math_2D_Force(float x, float y){
		
		return Mathf.Sqrt(Mathf.Pow(x,2)+Mathf.Pow(y,2));
	}
	
	// Checks
	
	public void OnDamage(float Damage){
		
		if (Invincible == 0){
			
			if (HP > Damage){
				
				LastHP = HP;
				HP -= Damage;
				AlphaInvincible = 0f;
				Invincible = 1;
				Eraser.Alpha = 1f;
				Invoke("Timer_InvincibleCool",3.0f);
				CameraScript.CamShake = 1f;
			}
			
			else if (HP != 0) {
				
				LastHP = HP;
				HP = 0;
				DEAD = 1;
				Eraser.Alpha = 1f;
				CameraScript.CamShake = 2f;
			}
		}
	}
	
	void OnInvincible(){
		if (Invincible == 1)
			AlphaInvincible += 0.1f;
		else if (DEAD == 1)
			AlphaInvincible = 1.2f;
		else
			AlphaInvincible = 0f;
	}
	
	// Gets
	
	float Get_angle_toPosition(Vector3 Pos){
		
		Vector3 BossPos = BossTransform.position;
		
		return ( Mathf.Atan2(Pos.y-BossPos.y, Pos.x-BossPos.x) * Mathf.Rad2Deg );
		
	}
	
	Vector2 Get_Force_Direction(){
		
		Vector3 PlayerPos = PlayerTransform.position;
		Vector3 BossPos = BossTransform.position;
		Vector3 PlayerPrivatePos = PlayerPos - BossPos;
		
		float RangeKey = Math_2D_Force(PlayerPrivatePos.x,PlayerPrivatePos.y);
		
		PlayerPrivatePos = PlayerPrivatePos/RangeKey;
		
		Vector2 ForceDirection = new Vector2(PlayerPrivatePos.x,PlayerPrivatePos.y);
		
		return ForceDirection;
	}
	
	Vector3 Get_Target_AngleToPos(float angle){
		return new Vector3(Mathf.Cos(angle*Mathf.Deg2Rad), Mathf.Sin(angle*Mathf.Deg2Rad), 0); 
	}
	
	
	Vector3 Get_Vector3_Direction(Vector3 Pos){
		
		Vector3 PlayerPos = Pos;
		Vector3 BossPos = BossTransform.position;
		Vector3 PlayerPrivatePos = PlayerPos - BossPos;
		
		float RangeKey = Math_2D_Force(PlayerPrivatePos.x,PlayerPrivatePos.y);
		
		PlayerPrivatePos = PlayerPrivatePos/RangeKey;
		
		Vector3 VectorDirection = new Vector3(PlayerPrivatePos.x,PlayerPrivatePos.y,0);
		
		return VectorDirection;
	}
	
	Quaternion Get_toPlayer_rotation(){
		
		Vector3 PlayerPos = PlayerTransform.position;
		Vector3 BossPos = BossTransform.position;
		
		float angle = Mathf.Atan2(PlayerPos.y-BossPos.y, PlayerPos.x-BossPos.x) * Mathf.Rad2Deg;
		
		Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		
		return rotation;
	}
	
	// Attacks
	
	GameObject Attack_Gen_Bullet(){
		
		Vector3 BossPos = BossTransform.position;
		
		BulletPool++;
		
		return Instantiate(BulletPrefab,BossPos,new Quaternion(0,0,0,0));
	}
	
	GameObject Attack_CheckandReturn(){
		
		int Key = 0;
		int i = 0;
		
		if (BulletPool != 0){
			for(;i<BulletPool; i++){
				if (Bullet[i].GetComponent<ctw_Bullet_behavior>().OnWork == false){
					Key = 1;
					break;
				}
			}
		}
		
		if (Key == 0){
			Bullet[i] = Attack_Gen_Bullet();
		}
		
		return Bullet[i];
	}
	
	void Attack_SetBullet(float Force,Vector3 Target,Quaternion rotation){
		
		GameObject Bullet = Attack_CheckandReturn();
		Vector3 BossPos = BossTransform.position;
		
		Transform BulletTransform = Bullet.GetComponent<Transform>();
		ctw_Bullet_behavior BulletScript = Bullet.GetComponent<ctw_Bullet_behavior>();
		
		BulletTransform.position = BossPos;
		BulletTransform.rotation = rotation;
		BulletScript.Vel = Get_Vector3_Direction(Target)*Force;
		BulletScript.OnWork = true;
	}
	
	// Attack Patterns
	
	void Attack_Melee(){
		
		// Is this code important or need?
	}
	
	void Attack_Pattern_0(){
		
		float angle = Get_angle_toPosition(PlayerTransform.position);
		Attack_SetBullet(30f,Get_Target_AngleToPos(angle),Quaternion.AngleAxis(angle, Vector3.forward));
		Attack_SetBullet(30f,Get_Target_AngleToPos(angle+7),Quaternion.AngleAxis(angle+7, Vector3.forward));
		Attack_SetBullet(30f,Get_Target_AngleToPos(angle-7),Quaternion.AngleAxis(angle-7, Vector3.forward));
		ATTACK = 1;
		Invoke("Timer_AttackCool",0.8f);
		if (Time >= 4){
			AttackType = 1;
			Time = 0;
		}
	}
	
	void Attack_Pattern_1(){
		for(float i = -180; i<180; i+=20){
			Attack_SetBullet(20f,Get_Target_AngleToPos(i),Quaternion.AngleAxis(i, Vector3.forward));
			Attack_SetBullet(16f,Get_Target_AngleToPos(i-10),Quaternion.AngleAxis(i-10, Vector3.forward));
		}
		ATTACK = 1;
		Invoke("Timer_AttackCool",1.0f);
		if (Time >= 3){
			AttackType = 0;
			Time = 0;
		}
	}
	
	
	// Running
	
	void Rendering(){
		
		float R = BossSprite.color.r;
		float G = BossSprite.color.g;
		float B = BossSprite.color.b;
		
		BossSprite.color = new Color(R, G, B, Mathf.Abs((Mathf.Cos(AlphaInvincible))) );
	}
	
	void Attacking(){
		if ((ATTACK == 0)&&(Invincible == 0)){
			Invoke("Attack_Pattern_"+AttackType.ToString() , 0f);
		}
	}
	
    void Update(){
        
		OnInvincible();
		
		if (DEAD == 0) Attacking();
		
		Rendering();
    }
}
