using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kmg_camera_behaviour : MonoBehaviour
{
	float colorValue, size = 9f;
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
		
		colorValue = (playerY + 15f) / 150f;
		if(colorValue >= 1f)
			colorValue = 1f;
	}
	
	void CameraControl()
	{
		if(playerY <= -3f)
			transform.position = new Vector3(playerX, -3f, 0f);
		
		else
			transform.position = new Vector3(playerX, playerY, 0f);
	}
	
	// Update is called once per frame
	void Update()
	{
		Initialize();
		CameraControl();
		cam.backgroundColor = new Color(0f, colorValue, colorValue, 1f);
	}
}
