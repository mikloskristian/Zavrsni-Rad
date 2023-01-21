using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreLoader : MonoBehaviour
{
    private TMP_Text _tekst;
    private GameObject _player;
    private Health _h;
    void Awake() {
        _tekst = GetComponent<TMP_Text>();    
    }
    void Start()
    {
        _player = GameObject.Find("Player");
        _h = _player.GetComponent<Health>();
        _h.SE.AddListener(updateScore);
        _tekst.text = "0";
    }
    void Update()
    {

    }

    void updateScore(float score)
    {
        Debug.Log("Primio sam ga. Jako");
    }
}
