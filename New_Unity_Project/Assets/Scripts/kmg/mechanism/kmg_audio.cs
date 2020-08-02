using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kmg_audio : MonoBehaviour
{
	AudioSource bgm;
	float vol;
	
	// Start is called before the first frame update
	void Start()
	{
		vol = 1f;
		
		bgm = GetComponent<AudioSource>();
		bgm.volume = vol;
		bgm.Play();
	}

	// Update is called once per frame
	void Update()
	{
		
	}
}
