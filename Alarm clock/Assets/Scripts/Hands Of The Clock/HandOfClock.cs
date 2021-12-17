using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HandOfClock : MonoBehaviour
{
    [SerializeField] protected RotatorHandsOfClock rotator;
    [SerializeField] protected int rotationAngle;
    [SerializeField] protected int delayTime;

    protected int startAngle;
    protected void ChangeStartAngle(int newAngle) => startAngle = newAngle;

    private void Start()
    {
        rotator.DoRotate(this, startAngle, rotationAngle, delayTime);
    }
}
