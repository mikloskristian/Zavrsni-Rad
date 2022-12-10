using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
                    Debug.Log("Napravio sam se");
                }
                return instance;
            }
        }
    }
    [HideInInspector] public int Score;
    [HideInInspector] public int EnemyAmmount;
    [HideInInspector] public float SpawnerTimer;

    public void Awake()
    {
        Score = 0;
    }

    private void Update() {
        
    }

    public void AddScore(int value, TMP_Text ScoreText)
    {
        Score += value;
        ScoreText.text = Score.ToString();
        Debug.Log(Score);
    }
}
