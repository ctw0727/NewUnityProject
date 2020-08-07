using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kmg_onoff : MonoBehaviour
{
	BoxCollider2D bc2d;
	PolygonCollider2D pc2d;
	SpriteRenderer sr;
	AudioSource[] sound;
	bool isOn;
	
	[Tooltip("최초로 이 블록이 꺼질 시간을 초단위로 설정하는 곳\n시간 계산: (On Off Duration) - (On Off Timer)")]
	public float OnOffTimer = 0f;
	[Tooltip("최초로 이 블록이 꺼지고 난 후 깜박이는 간격을 초단위로 설정하는 곳")]
	public float OnOffDuration = 1.5f;
	
	// Start is called before the first frame update
	void Start()
	{
		bc2d = gameObject.GetComponent<BoxCollider2D>();
		pc2d = gameObject.GetComponent<PolygonCollider2D>();
		sr = gameObject.GetComponent<SpriteRenderer>();
		sound = gameObject.GetComponents<AudioSource>();
		
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
				sound[1].Play();
				
				OnOffTimer -= OnOffDuration;
				isOn = false;
			}
			
			else
			{
				sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f);
				bc2d = gameObject.AddComponent<BoxCollider2D>();
				pc2d = gameObject.AddComponent<PolygonCollider2D>();
				sound[0].Play();
				
				pc2d.isTrigger = true;
				OnOffTimer -= OnOffDuration;
				isOn = true;
			}
		}
	}
}
