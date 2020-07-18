using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ssh_move: MonoBehaviour
{
	
	public float MaxSpeed;
	public float JumpPower;
	Rigidbody2D rigid;
	
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {	
		//점프
		if (Input.GetButtonDown("Jump"))
			rigid.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
		
		//움직임
		float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);
		
		if(rigid.velocity.x > MaxSpeed)						//오른쪽 속도 제어
			rigid.velocity = new Vector2(MaxSpeed, rigid.velocity.y);
			
		else if(rigid.velocity.x < MaxSpeed * (-1))			//왼쪽 속도 제어
			rigid.velocity = new Vector2(MaxSpeed * (-1), rigid.velocity.y);
	}
}
