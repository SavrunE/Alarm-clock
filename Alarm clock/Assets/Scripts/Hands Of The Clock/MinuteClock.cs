using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinuteClock : HandOfClock
{
    private const int angleInOneMinute = 360 / 60;
    private const int maxSeconds = 60;
    protected override void ChangeClock()
    {
        startAngle = timeTaker.Minutes * angleInOneMinute + timeTaker.Seconds / (maxSeconds / angleInOneMinute);
        CorrectionRotate();
    }
}
