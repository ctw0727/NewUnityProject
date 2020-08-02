using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kmg_stage2 : MonoBehaviour
{
	BoxCollider2D thisBC;
	
	public GameObject player;
	public Rigidbody2D playerRB;
	
	// Start is called before the first frame update
	void Start()
	{
		thisBC = gameObject.GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update()
	{
		if(playerRB.IsTouching(thisBC))
		{
			player.transform.position = new Vector3(178f, 36f, player.transform.position.z);
			playerRB.velocity = new Vector2(0f, 0f);
		}
	}
}
