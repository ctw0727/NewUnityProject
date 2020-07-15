﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kmg_player_behaviour : MonoBehaviour
{
	private Rigidbody2D rb2D;
	
	public Vector3 spawnpoint;
	public float maxSpeed;
	public float accel;
	public int attempt;
	
	// Start is called before the first frame update
	void Start()
	{
		spawnpoint = new Vector3(-13.5f, -6.5f, 0f);
		maxSpeed = 9f;
		accel = 0.9f;
		attempt = 1;
		
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
		
		if(Input.GetKeyDown(KeyCode.Space))
			rb2D.velocity = new Vector2(rb2D.velocity[0], 18.0f);
		
		if(transform.position.y <= -15f || Input.GetKeyDown(KeyCode.R))
		{
			transform.position = spawnpoint;
			rb2D.velocity = new Vector2(0f, 0f);
			attempt++;
		}
	}
	
	// Update is called once per frame
	void Update()
	{
		Operation();
	}
}
