using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kmg_init_position : MonoBehaviour
{
	Rigidbody2D rb2d;
	
	public Vector2 initialRB2DPos;
	
	// Start is called before the first frame update
	void Start()
	{
		rb2d = gameObject.GetComponent<Rigidbody2D>();
		
		rb2d.position = new Vector2(initialRB2DPos.x, initialRB2DPos.y);
	}

	// Update is called once per frame
	void Update()
	{
		
	}
}

// 스크립트 오브젝트에서 Rigidbody2D 클래스 상의 위치를 직접 조정할 수 있게 설정
// (원래 인스펙터에서 직접 조정 못하게 해놨음)
// 여기서 설정한 위치를 transform 클래스의 위치와 똑같이 맞추어 놓아야 함
