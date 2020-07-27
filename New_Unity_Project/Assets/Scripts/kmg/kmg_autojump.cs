using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kmg_autojump : MonoBehaviour
{
	Rigidbody2D this_rb;
	BoxCollider2D this_bc;
	
	public GameObject player;
	public Rigidbody2D player_rb;
	public CircleCollider2D player_cc;
	
	// Start is called before the first frame update
	void Start()
	{
		this_rb = gameObject.GetComponent<Rigidbody2D>();
		this_bc = gameObject.GetComponent<BoxCollider2D>();
	}

	// Update is called once per frame
	void Update()
	{
		if(this_bc.IsTouching(player_cc))
			player_rb.velocity = new Vector2(player_rb.velocity.x, 24f);
	}
}
