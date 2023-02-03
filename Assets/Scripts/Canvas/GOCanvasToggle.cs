using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GOCanvasToggle : MonoBehaviour
{
    [SerializeField] private Canvas _gameOnCanvas;
    [SerializeField] private Canvas _gameOverCanvas;
    private GameObject _player;
    private Health _health;
    public GOCanvasEvent CE;
    void Start()
    {
        this._player = GameObject.Find("Player");
        this._health = _player.GetComponent<Health>();
        this._health.DE.AddListener(handleDeath);

        if(this.CE == null)
        {
            this.CE = new GOCanvasEvent();
        }

        _gameOverCanvas.enabled = false;
        _gameOnCanvas.enabled = true;
    }

    private void handleDeath(bool isDead)
    {
        if(isDead)
        {
            _gameOverCanvas.enabled = true;
            _gameOnCanvas.enabled = false;
            this.CE.Invoke(true);
        }
    }
}
[System.Serializable]
public class GOCanvasEvent : UnityEvent<bool>{}
