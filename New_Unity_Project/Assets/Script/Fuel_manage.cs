using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fuel_manage : MonoBehaviour
{
    [SerializeField] float maxFuel;
    float curFuel;
    [SerializeField] Slider slider_JetEngine;

    public bool IsFuel{get; private set;}

    void Start()
    {
        curFuel = maxFuel;
        slider_JetEngine.maxValue = maxFuel;
        slider_JetEngine.value = curFuel;
    }

    void Update()
    {
        if(GameObject.FindWithTag("Boost"))
        {
            curFuel -= 1;
            slider_JetEngine.value = curFuel;

            if(curFuel <= 0)
            {
                curFuel = 0;
            }
        }
        else
        {
            curFuel += 1;

            if(curFuel >= 100)
            {
                curFuel = 100;
            }
        }

        if(curFuel > 0)
        {
            IsFuel = true;
        }
        else
        {
            IsFuel = false;
        }
    }
}
