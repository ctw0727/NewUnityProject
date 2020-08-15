using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kmg_player_behaviour : MonoBehaviour
{
	Rigidbody2D rb2D;
	AudioSource sound;
	bool jumping;
	float accel, maxSpeed;
	
	[Tooltip("이 플레이어의 최초 시작 지점")]
	public Vector3 spawnpoint;
	
	void Initialize()
	{
		maxSpeed = 9f;
		accel = 0.9f;
		jumping = false;
		
		rb2D = gameObject.GetComponent<Rigidbody2D>();
		sound = gameObject.GetComponent<AudioSource>();
		transform.position = spawnpoint;
	}
	
	void Operation()
	{
		if(Input.GetKey(KeyCode.A))
		{
			if(rb2D.velocity.x <= -maxSpeed)
				rb2D.velocity = new Vector2(-maxSpeed, rb2D.velocity[1]);
			
			rb2D.velocity += new Vector2(-accel, 0f);
		}
		
		if(Input.GetKey(KeyCode.D))
		{
			if(rb2D.velocity.x >= maxSpeed)
				rb2D.velocity = new Vector2(maxSpeed, rb2D.velocity[1]);
			
			rb2D.velocity += new Vector2(accel, 0f);
		}
		
		if(Input.GetKeyDown(KeyCode.Space) && !jumping)
		{
			rb2D.velocity = new Vector2(rb2D.velocity[0], 15.75f);
			sound.Play();
			jumping = true;
		}
		
		if(Input.GetKeyDown(KeyCode.R))
		{
			transform.position = spawnpoint;
			rb2D.velocity = new Vector2(0f, 0f);
		}
	}
	
	// 땅에 닿았음을 감지해주는 함수
	void OnTriggerEnter2D(Collider2D other)
	{
		jumping = false;
	}
	
	// Start is called before the first frame update
	void Start()
	{
		Initialize();
	}
	
	// Update is called once per frame
	void Update()
	{
		Operation();
	}
}
