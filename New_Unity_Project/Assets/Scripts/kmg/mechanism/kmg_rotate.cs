using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kmg_rotate : MonoBehaviour
{
	Rigidbody2D rb2d;
	
	public float aVel = -135f;
	
	// Start is called before the first frame update
	void Start()
	{
		rb2d = gameObject.GetComponent<Rigidbody2D>();
		
		rb2d.angularVelocity = aVel;
	}

	// Update is called once per frame
	void Update()
	{
		
	}
}
