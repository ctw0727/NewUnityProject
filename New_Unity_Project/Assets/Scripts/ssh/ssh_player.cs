using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ssh_player : MonoBehaviour
{
	Rigidbody2D PlayerRigid2D;
	Transform PlayerTransform;
	
    // Start is called before the first frame update
    void Start()
    {
        PlayerTransform = GetComponent<Transform>();
		PlayerRigid2D = GetComponent<Rigidbody2D>();
    }

	void Move()
	{
		float XMovecount = 0;
		float YMovecount = 0;
		
		if (Input.GetKey(KeyCode.A))
			XMovecount--;
		if (Input.GetKey(KeyCode.D))
			XMovecount++;
		if (Input.GetKey(KeyCode.W))
			YMovecount++;
		if (Input.GetKey(KeyCode.S))
			YMovecount--;
		
		PlayerRigid2D.velocity = new Vector2(20*XMovecount, 20*YMovecount);
	}
	
    // Update is called once per frame
    void Update()
    {
        Move();
    }
}
