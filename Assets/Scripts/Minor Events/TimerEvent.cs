using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimerEvent : MonoBehaviour
{
    private float _timer;
    [HideInInspector] public bool TimerUpdate;
    public SpawnerEvent SE;
    void Start()
    {
        if(SE == null)
        {
            SE = new SpawnerEvent();
        }
    }

    void Update()
    {
        UpdateTimer();
    }

    void UpdateTimer()
    {
        _timer += Time.deltaTime;
        if(_timer >= 45.0f)
        {
            _timer = 0.0f;
            TimerUpdate = true;
            SE.Invoke(TimerUpdate);
        }
        TimerUpdate = false;
    }
}
[System.Serializable]
public class SpawnerEvent : UnityEvent<bool> {}
