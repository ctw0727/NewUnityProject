using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ctw_Boss_behavior : MonoBehaviour
{
	
	public bool STUN = false;
	public GameObject BulletPrefab;
	
	Transform PlayerTransform;
	Rigidbody2D PlayerRigid2D;
	ctw_Player_behavior PlayerScript;
	
	Transform BossTransform;
	
	GameObject[] Bullet = new GameObject[100];
	int BulletPool = 0;
	
	int ATTACK = 0;
	
	int AttackType = 0;
	
	int Time = 0;
	
    void Start(){
        
		PlayerTransform = GameObject.Find("ctw_Player").GetComponent<Transform>();
		PlayerRigid2D = GameObject.Find("ctw_Player").GetComponent<Rigidbody2D>();
		PlayerScript = GameObject.Find("ctw_Player").GetComponent<ctw_Player_behavior>();
		
		BossTransform = GetComponent<Transform>();
		Invoke("Timer_ticker",1.0f);
    }
	
	// Timers
	
	void Timer_ticker(){
		
		Time++;
		Invoke("Timer_ticker",1.0f);
	}
	
	void Timer_STUNCool(){
		
		STUN = false;
	}
	
	void Timer_AttackCool(){
		
		ATTACK = 0;
	}
	
	// Maths
	
	float Math_2D_Force(float x, float y){
		
		return Mathf.Sqrt(Mathf.Pow(x,2)+Mathf.Pow(y,2));
	}
	
	// Gets
	
	Vector2 Get_Force_Direction(){
		
		Vector3 PlayerPos = PlayerTransform.position;
		Vector3 BossPos = BossTransform.position;
		Vector3 PlayerPrivatePos = PlayerPos - BossPos;
		
		float RangeKey = Math_2D_Force(PlayerPrivatePos.x,PlayerPrivatePos.y);
		
		PlayerPrivatePos = PlayerPrivatePos/RangeKey;
		
		Vector2 ForceDirection = new Vector2(PlayerPrivatePos.x,PlayerPrivatePos.y);
		
		return ForceDirection;
	}
	
	Vector3 Get_Vector3_Direction(){
		
		Vector3 PlayerPos = PlayerTransform.position;
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
	
	void Attack_Melee(){
		
		
	}
	
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
	
	void Attack_SetBullet(float Force,Quaternion rotation){
		
		GameObject Bullet = Attack_CheckandReturn();
		Vector3 BossPos = BossTransform.position;
		
		Transform BulletTransform = Bullet.GetComponent<Transform>();
		ctw_Bullet_behavior BulletScript = Bullet.GetComponent<ctw_Bullet_behavior>();
		
		BulletTransform.position = BossPos;
		BulletTransform.rotation = rotation;
		BulletScript.Vel = Get_Vector3_Direction()*Force;
		BulletScript.OnWork = true;
	}
	
	// Attack Patterns
	
	void Attack_Pattern_right(){
		
	}
	
	
	// Running
	
	void Attacking(){
		
		if (ATTACK == 0){
			
			Attack_SetBullet(10f,Get_toPlayer_rotation());
			ATTACK = 1;
			Invoke("Timer_AttackCool",1.0f);
		}
	}
	
    void Update(){
        
		Attacking();
    }
}
