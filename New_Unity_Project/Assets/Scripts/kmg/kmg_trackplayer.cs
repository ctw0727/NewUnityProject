using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kmg_trackplayer : MonoBehaviour
{
	float size = 5f;
	Camera cam;
	
	public GameObject player;
	
	// Start is called before the first frame update
	void Start()
	{
		cam = gameObject.GetComponent<Camera>();
		
		cam.orthographicSize = size;
	}

	// Update is called once per frame
	void Update()
	{
		transform.position = new Vector3(player.transform.position[0], player.transform.position[1], 0f);
	}
}
