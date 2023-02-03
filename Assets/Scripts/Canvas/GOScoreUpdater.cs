using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GOScoreUpdater : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _goScoreText;
    private GameObject _player;
    private Health _health;
    private bool _isDead;
    void Start()
    {
        this._player = GameObject.Find("Player");
        this._health = _player.GetComponent<Health>();
        this._health.DE.AddListener(handleDeath);
    }
    private void Update() {
        if(_isDead)
        {
            _goScoreText.text = "Your Score: " + _scoreText.text;
        }
    }

    private void handleDeath(bool isDead)
    {
        this._isDead = isDead;
    }
}
