using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ctw_Platform_behavior : MonoBehaviour
{
	
	public bool Trigger = false;
	
	int DownCool = 0;
	
	Transform PlatformTransform;
	BoxCollider2D PlatformCollider;
	
	Transform PlayerTransform;
	
    // Start is called before the first frame update
    void Start(){
		
        PlatformTransform = GetComponent<Transform>();
		PlatformCollider = gameObject.AddComponent<BoxCollider2D>() as BoxCollider2D;
		PlatformCollider.offset = new Vector2(0,-1);
		PlatformCollider.size = new Vector2(1,2);
		
		PlayerTransform = GameObject.Find("ctw_Player").GetComponent<Transform>();
    }
	
	void Control(){
		
		ctw_Player_behavior CallScript = GameObject.Find("ctw_Player").GetComponent<ctw_Player_behavior>();
		
		if ((PlayerTransform.position.y >= PlatformTransform.position.y + 0.49f)&&(DownCool == 0)){
			PlatformCollider.isTrigger = false;
			
			if ((CallScript.DOWN == true)&&(PlayerTransform.position.y - PlatformTransform.position.y <= 2f)){
				PlatformCollider.isTrigger = true;
				DownCool = 1;
				Invoke("Cooler",0.5f);
			}
		}
		if ((PlayerTransform.position.y < PlatformTransform.position.y -0.49f)&&(DownCool == 0)){
			PlatformCollider.isTrigger = true;
		}
	}
	
	void Cooler(){
		DownCool = 0;
	}

    // Update is called once per frame
    void Update(){
		
		Control();
		
		Trigger = PlatformCollider.isTrigger;
    }
}
