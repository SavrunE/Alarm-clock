using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HourClock : HandOfClock
{
    [SerializeField] private TimeTaker timeTaker;
    private void OnEnable()
    {
        //timeTaker.OnTimeParsed += 
    }

    private void ChangeClock(TimeTaker timeTaker)
    {
    }
}
