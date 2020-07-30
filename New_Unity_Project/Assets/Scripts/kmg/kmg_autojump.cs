﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kmg_autojump : MonoBehaviour
{
	Rigidbody2D thisRB;
	BoxCollider2D thisBC;
	
	public GameObject player;
	public Rigidbody2D playerRB;
	public CircleCollider2D playerCC;
	
	// Start is called before the first frame update
	void Start()
	{
		thisRB = gameObject.GetComponent<Rigidbody2D>();
		thisBC = gameObject.GetComponent<BoxCollider2D>();
	}

	// Update is called once per frame
	void Update()
	{
		if(thisBC.IsTouching(playerCC))
			playerRB.velocity = new Vector2(playerRB.velocity.x, 24f);
	}
}
