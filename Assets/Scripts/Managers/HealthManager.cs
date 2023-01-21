using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HealthManager
{
    private static HealthManager instance = null;
    private static readonly object padlock = new object();

    HealthManager()
    {
    }

    public static HealthManager Instance
    {
        get
        {
            lock(padlock)
            {
                if(instance == null)
                {
                    instance = new HealthManager();
                }
                return instance;
            }
        }
    }
    public void SetHealthValue(float value, Slider healthSlider)
    {
        healthSlider.maxValue = value;
    }

    public void RemoveHealthValue(float value, Slider healthSlider)
    {
        healthSlider.value = value;
    }
}
