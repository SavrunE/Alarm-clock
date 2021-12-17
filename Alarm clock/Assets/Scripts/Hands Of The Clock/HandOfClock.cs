using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HandOfClock : MonoBehaviour
{
    [SerializeField] protected TimeTaker timeTaker;
    [SerializeField] protected RotatorHandsOfClock rotator;
    protected const float rotationAngle = 360f;
    [SerializeField] protected int SecondsForFullRotate;

    protected int startAngle;
    protected void ChangeStartAngle(int newAngle) => startAngle = newAngle;

    protected abstract void ChangeClock();

    private void Start()
    {
        StartRotate();
    }

    private void StartRotate()
    {
        float delay = SecondsForFullRotate / rotationAngle;
        rotator.DoRotate(this, -startAngle, 1, delay);
    }

    protected void CorrectionRotate( )
    {
        StopRotate();
        StartRotate();
    }

    private void StopRotate()
    {
        rotator.StopRotate(this);
    }
    protected void OnEnable()
    {
        timeTaker.OnTimeParsed += ChangeClock;
    }

    protected void OnDisable()
    {
        timeTaker.OnTimeParsed -= ChangeClock;
    }
}
