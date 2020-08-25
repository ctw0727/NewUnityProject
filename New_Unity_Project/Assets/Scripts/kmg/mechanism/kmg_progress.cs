using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class kmg_progress : MonoBehaviour
{
	float progress;
	
	public Text showing;
	public Rigidbody2D playerRB;
	
	// Start is called before the first frame update
	void Start()
	{
		showing = gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update()
	{
		progress = (playerRB.position.x+11f) / (560f+11f) * 100f;
		if(progress <= 0f) progress = 0f;
		else if(progress >= 100f) progress = 100f;
		
		showing.text = "현재 진행률: " + progress.ToString("F1") + "%";
		showing.color = Color.Lerp(Color.red, Color.yellow, progress/100f);
	}
}
