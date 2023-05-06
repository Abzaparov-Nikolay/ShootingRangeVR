using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public TimeLeftSO timeLeft;
    public bool TimerON;
    
    public UnityEvent OnStop;

    // Start is called before the first frame update
    void Start()
    {
        //TimerON = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!TimerON)
        {
            return;
        }
        
        timeLeft.Set(timeLeft.Get() - Time.deltaTime >= 0 ? timeLeft.Get() - Time.deltaTime : 0);

        if (timeLeft.Get() <= 0)
        {
            TimerON = false;
            OnStop?.Invoke();
        }
    }

    [ContextMenu("StartAgain")]
    public void StartAgain()
    {
        timeLeft.ResetValue();
        TimerON = false;
    }

    public void StartIfPaused()
    {
        TimerON = true;
    }
}
