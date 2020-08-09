using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kmg_moving_LR : MonoBehaviour
{
	Rigidbody2D rb2D;
	bool move_right;
	
	[Tooltip("이 블록이 움직이는 길의 왼쪽 끝 x좌표")]
	public float leftLimit = -9f;
	[Tooltip("이 블록이 움직이는 길의 오른쪽 끝 x좌표")]
	public float rightLimit = 9f;
	
	void PathControl()
	{
		if(rb2D.position.x <= leftLimit)
			move_right = true;
		
		else if(rb2D.position.x >= rightLimit)
			move_right = false;
	}
	
	void Move()
	{
		if(move_right)
			rb2D.velocity = new Vector2(7f, 0f);
		
		else
			rb2D.velocity = new Vector2(-7f, 0f);
	}

	// Start is called before the first frame update
	void Start()
	{
		rb2D = gameObject.GetComponent<Rigidbody2D>();
		move_right = true;
	}
	
	// Update is called once per frame
	void Update()
	{
		PathControl();
		Move();
	}
}
