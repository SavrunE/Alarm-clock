using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HandOfClock : MonoBehaviour
{
    [SerializeField] protected RotatorHandsOfClock rotator;
    protected float rotationAngle;
    [SerializeField] protected int SecondsForFullRotate;

    protected int startAngle;
    protected void ChangeStartAngle(int newAngle) => startAngle = newAngle;

    private void Start()
    {
        rotationAngle = 360f;
        float delay = SecondsForFullRotate / rotationAngle;
        rotator.DoRotate(this, startAngle, 1, delay);
    }

    public void StopRotate()
    {
        rotator.StopRotate(this);
    }
}
