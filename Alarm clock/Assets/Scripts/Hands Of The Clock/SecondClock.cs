using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondClock : HandOfClock
{
    private const int angleInOneSecond = 360 / 60;
    protected override void ChangeClock()
    {
        startAngle = timeTaker.Seconds * angleInOneSecond;
        CorrectionRotate();
    }
}
