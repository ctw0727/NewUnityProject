﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ctw_Healthbar_behavior : MonoBehaviour
{
	
	Image SelfImage;
	
	ctw_Boss_behavior Boss;
	ctw_Eraser_behavior Eraser;
	
    void Start(){
		
		SelfImage = GetComponent<Image>();
		
		Boss = GameObject.Find("ctw_Boss").GetComponent<ctw_Boss_behavior>();
		Eraser = GameObject.Find("ctw_Eraser_Boss").GetComponent<ctw_Eraser_behavior>();
    }
	
    void Update(){
		
		float CurrentHP = ( Boss.HP / Boss.MaxHP );
		float LastHP = ( Boss.LastHP / Boss.MaxHP );
		
		switch (gameObject.name){
			
			case "ctw_HealthBar_Red":
				SelfImage.fillAmount = CurrentHP;
			break;
			
			case "ctw_HealthBar_Yellow":
				SelfImage.fillAmount = LastHP;
				if (Boss.LastHP > Boss.HP) Boss.LastHP -= Mathf.Pow((Boss.LastHP / Boss.HP)*2,3);
				if (Boss.LastHP <= Boss.HP) Boss.LastHP = Boss.HP;
			break;
		}
    }
}
