using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HourClock : HandOfClock
{
    private const int anglesInOneHour = 360 / 12;
    private const int maxMinutes = 60;
    private const int maxHours = 12;
    protected override void ChangeClock()
    {
        int hours = timeTaker.Hours;
        if (hours > maxHours)
        {
            hours -= maxHours;
        }
        startAngle = hours * anglesInOneHour + timeTaker.Minutes / (maxMinutes/ anglesInOneHour);
        CorrectionRotate();
    }
}
