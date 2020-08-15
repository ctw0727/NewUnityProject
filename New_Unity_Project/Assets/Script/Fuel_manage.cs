using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fuel_manage : MonoBehaviour
{
    [SerializeField] float maxFuel;
    float curFuel;

    [SerializeField] Slider slider_JetEngine;

    [SerializeField] float waitRecharge;
    float curwaitRecharge;

    public bool IsFuel{get; private set;}

    void Start()
    {
        curFuel = maxFuel;
        slider_JetEngine.maxValue = maxFuel;
        slider_JetEngine.value = curFuel;
    }

    void Update()
    {
        slider_JetEngine.value = curFuel;

        if(GameObject.FindWithTag("Boost"))
        {
            curFuel -= 0.4f;
            

            if(curFuel <= 0)
            {
                curFuel = 0;
            }
        }
        else
        {
            FuelRecharge();
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

    void FuelRecharge()
    {
        if(curFuel < maxFuel && curFuel > 0)
        {
            curFuel += 0.1f;
        }

        else if(curFuel <= 0)
        {
            curwaitRecharge += Time.deltaTime;

            if(curwaitRecharge >= waitRecharge)
            {
                curFuel += 0.1f;
                curwaitRecharge = 0;
            }
        }
    }
}
