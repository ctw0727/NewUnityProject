using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kmg_moving_LR : MonoBehaviour
{
	Rigidbody2D rb2D;
	BoxCollider2D bc2D;
	bool move_right;
	
	public Vector2 initialRB2DPos;
	
	void PathControl()
	{
		if(rb2D.position.x <= -9.0f)
		{
			rb2D.MovePosition(rb2D.position + new Vector2(0.3f, 0f));
			move_right = true;
		}
		
		else if(rb2D.position.x >= 9.0f)
		{
			rb2D.MovePosition(rb2D.position - new Vector2(0.3f, 0f));
			move_right = false;
		}
	}
	
	void Move()
	{
		if(move_right)
			rb2D.velocity = new Vector2(7.0f, 0f);
		
		else
			rb2D.velocity = new Vector2(-7.0f, 0f);
	}

	// Start is called before the first frame update
	void Start()
	{
		rb2D = gameObject.GetComponent<Rigidbody2D>();
		bc2D = gameObject.GetComponent<BoxCollider2D>();
		rb2D.position = new Vector2(initialRB2DPos.x, initialRB2DPos.y);
		move_right = true;
	}
	
	// Update is called once per frame
	void Update()
	{
		PathControl();
		Move();
	}
}
