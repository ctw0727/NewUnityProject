using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kmg_onoff : MonoBehaviour
{
	BoxCollider2D bc2d;
	PolygonCollider2D pc2d;
	SpriteRenderer sr;
	bool isOn;
	
	// 온오프 타이머 값을 인스펙터에서 따로 초기화해서 블록이 차례대로 깜박이게 할 것
	public float OnOffTimer = 0f;
	public float OnOffDuration = 1.5f;
	
	// Start is called before the first frame update
	void Start()
	{
		bc2d = gameObject.GetComponent<BoxCollider2D>();
		pc2d = gameObject.GetComponent<PolygonCollider2D>();
		sr = gameObject.GetComponent<SpriteRenderer>();
		
		isOn = true;
		sr.color = Color.yellow;
	}

	// Update is called once per frame
	void Update()
	{
		OnOffTimer += Time.deltaTime;
		
		if(OnOffTimer > OnOffDuration)
		{
			if(isOn)
			{
				sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.2f);
				Destroy(GetComponent<BoxCollider2D>());
				Destroy(GetComponent<PolygonCollider2D>());
				
				isOn = false;
				OnOffTimer = 0f;
			}
			
			else
			{
				sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f);
				bc2d = gameObject.AddComponent<BoxCollider2D>();
				pc2d = gameObject.AddComponent<PolygonCollider2D>();
				
				pc2d.isTrigger = true;
				isOn = true;
				OnOffTimer = 0f;
			}
		}
	}
}
