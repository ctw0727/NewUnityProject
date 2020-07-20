using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kmg_rotate : MonoBehaviour
{
	Rigidbody2D rb2d;
	float aVel = 225f;
	
	public Vector2 initialRB2DPos;
	
	// Start is called before the first frame update
	void Start()
	{
		rb2d = gameObject.GetComponent<Rigidbody2D>();
		
		rb2d.position = new Vector2(initialRB2DPos.x, initialRB2DPos.y);
		rb2d.centerOfMass = new Vector2(-2.5f, 0f);
		rb2d.angularVelocity = aVel;
	}

	// Update is called once per frame
	void Update()
	{
		
	}
}
