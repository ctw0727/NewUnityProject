using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kmg_morejump : MonoBehaviour
{
	Rigidbody2D thisRB;
	SpriteRenderer thisSR;
	PolygonCollider2D thisPC;
	AudioSource sound;
	
	bool used;
	float aVel = 180f;
	float regenTimer = 0f, regenCool = 1.5f;
	
	public GameObject player;
	public Rigidbody2D playerRB;
	
	// Start is called before the first frame update
	void Start()
	{
		thisRB = gameObject.GetComponent<Rigidbody2D>();
		thisSR = gameObject.GetComponent<SpriteRenderer>();
		thisPC = gameObject.GetComponent<PolygonCollider2D>();
		sound = gameObject.GetComponent<AudioSource>();
		
		thisRB.angularVelocity = aVel;
		thisSR.color = Color.red;
		used = false;
	}

	// Update is called once per frame
	void Update()
	{
		if(!used)
		{
			if(playerRB.IsTouching(thisPC))
			{
				Destroy(GetComponent<PolygonCollider2D>());
				thisSR.color = new Color(1f, 0f, 0f, 0.1f);
				sound.Play();
				used = true;
			}
		}
		
		else
		{
			regenTimer += Time.deltaTime;
			
			if(regenTimer > regenCool)
			{
				thisPC = gameObject.AddComponent<PolygonCollider2D>();
				thisPC.isTrigger = true;
				
				thisSR.color = new Color(1f, 0f, 0f, 1f);
				regenTimer = 0f;
				used = false;
			}
		}
	}
}
