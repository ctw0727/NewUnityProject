using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kmg_camera_behaviour : MonoBehaviour
{
	float greenValue, size = 7f;
	float playerX, playerY;
	Camera cam;
	
	public GameObject player;
	
	// Start is called before the first frame update
	void Start()
	{
		cam = gameObject.GetComponent<Camera>();
		
		cam.orthographicSize = size;
	}
	
	void FOVcontrol()
	{
		// 또하나의 실험적 디버그 if문
		if(Input.GetKeyDown(KeyCode.X))
		{
			switch((int)size)
			{
				case 7:
					size = 14f;
					break;
				
				case 14:
					size = 7f;
					break;
			}
			
			cam.orthographicSize = size;
		}
	}
	
	void Initialize()
	{
		playerX = player.transform.position[0];
		playerY = player.transform.position[1];
		
		greenValue = (playerY + 15f) / 45f;
		if(greenValue >= 0.7f)
			greenValue = 0.7f;
	}

	// Update is called once per frame
	void Update()
	{
		FOVcontrol();
		Initialize();
		transform.position = new Vector3(playerX, playerY, 0f);
		cam.backgroundColor = new Color(0f, greenValue, 0f, 1f);
		// 메인카메라 배경색으로 y좌표를 최대 약 20까지 알 수 있게 하였음
	}
}
