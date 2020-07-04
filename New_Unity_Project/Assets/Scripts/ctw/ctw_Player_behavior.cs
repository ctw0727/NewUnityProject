using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ctw_Player_behavior : MonoBehaviour
{
	Transform PlayerTransform;
	Rigidbody2D PlayerRigid2D;
	
    // Start is called before the first frame update
    void Start()
    {
        PlayerTransform = GetComponent<Transform>();
		PlayerRigid2D = GetComponent<Rigidbody2D>();
		
    }

	void Move(){
		
		float XMoveCount = 0;
		float YMoveCount = 0;
		
		if (Input.GetKey(KeyCode.A))
			XMoveCount--;
		if (Input.GetKey(KeyCode.D))
			XMoveCount++;
		if (Input.GetKey(KeyCode.W))
			YMoveCount++;
		if (Input.GetKey(KeyCode.S))
			YMoveCount--;
		
		PlayerRigid2D.velocity = new Vector2(20*XMoveCount,20*YMoveCount);
	}

    // Update is called once per frame
    void Update()
    {
        Move();
    }
}
