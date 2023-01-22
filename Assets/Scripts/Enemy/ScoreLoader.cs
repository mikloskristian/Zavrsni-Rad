using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class ScoreLoader : MonoBehaviour
{
    public static ScoreLoader Instance;
    private TMP_Text _tekst;
    private GameObject _enemy;
    private Health _h;
    [HideInInspector] public float TotalScore;
    void Awake() {
        if(Instance == null)
        {
            Instance = this;
        }
        _tekst = GetComponent<TMP_Text>();    
    }
    void Start()
    {
        TotalScore = 0.0f;
        _tekst.text = "0";
    }
    void Update()
    {

    }

    public void updateScore(float score)
    {
        TotalScore += score;
        _tekst.text = TotalScore.ToString();
    }
}
