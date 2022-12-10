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
                    Debug.Log("Napravio sam se");
                }
                return instance;
            }
        }
    }

    public void Awake()
    {
    }
    public void SetStartingHealth(float value, Slider healthSlider)
    {
        healthSlider.maxValue = value;
        healthSlider.value = value; 
    }

    public void RemoveHealthOnSlider(float value, Slider healthSlider)
    {
        healthSlider.value -= value;
    }
}
