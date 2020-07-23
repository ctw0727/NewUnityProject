﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kmg_player_behaviour : MonoBehaviour
{
	Rigidbody2D rb2D;
	int attempt;
	bool jumping;
	float accel, maxSpeed;
	
	public Vector3 spawnpoint;
	
	void Initialize()
	{
		spawnpoint = new Vector3(-13.5f, -6.5f, spawnpoint.z);
		maxSpeed = 9f;
		accel = 0.9f;
		attempt = 1;
		jumping = false;
		
		rb2D = gameObject.GetComponent<Rigidbody2D>();
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
			rb2D.velocity = new Vector2(rb2D.velocity[0], 16.0f);
			jumping = true;
		}
		
		if(transform.position.y <= -15f || Input.GetKeyDown(KeyCode.R))
		{
			transform.position = spawnpoint;
			rb2D.velocity = new Vector2(0f, 0f);
			attempt++;
			Debug.Log("Attempt count is now " + attempt);
		}
		
		// 디버그 목적으로 만들어진 if문 (추후 삭제될 예정)
		if(Input.GetKeyDown(KeyCode.Z))
		{
			transform.position = new Vector3(35.5f, -3.5f, transform.position[2]);
			rb2D.velocity = new Vector2(0f, 0f);
		}
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		jumping = false;
		Debug.Log("Now player can jump");
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
