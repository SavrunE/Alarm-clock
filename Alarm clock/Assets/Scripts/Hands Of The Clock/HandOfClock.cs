using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HandOfClock : MonoBehaviour
{
    [SerializeField] protected RotatorHandsOfClock rotator;
    [SerializeField] protected int startAngle;
    [SerializeField] protected int angle;
    [SerializeField] protected int delay;

    private void Start()
    {
        rotator.DoRotate(this, startAngle, angle, delay);
    }
}
