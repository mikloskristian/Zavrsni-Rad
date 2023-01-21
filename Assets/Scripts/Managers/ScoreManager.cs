using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public sealed class ScoreManager
{
    private static ScoreManager instance = null;
    private static readonly object padlock = new object();

    ScoreManager()
    {
    }

    public static ScoreManager Instance
    {
        get
        {
            lock(padlock)
            {
                if(instance == null)
                {
                    instance = new ScoreManager();
                }
                return instance;
            }
        }
    }
    [HideInInspector] public float Score;

    private void Update() {
        
    }
    public void AddScore(float value, TMP_Text ScoreText)
    {
        Score += value;
        ScoreText.text = Score.ToString();
        Debug.Log(Score);
    }
}
