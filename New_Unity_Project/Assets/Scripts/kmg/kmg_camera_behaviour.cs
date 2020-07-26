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
	
	void Initialize()
	{
		playerX = player.transform.position[0];
		playerY = player.transform.position[1];
		
		greenValue = (playerY + 15f) / 90f;
		if(greenValue >= 0.7f)
			greenValue = 0.7f;
	}

	// Update is called once per frame
	void Update()
	{
		Initialize();
		transform.position = new Vector3(playerX, playerY, 0f);
		cam.backgroundColor = new Color(0f, greenValue, 0f, 1f);
		// 메인카메라 배경색으로 y좌표를 최대 63까지 알 수 있게 하였음
	}
}
