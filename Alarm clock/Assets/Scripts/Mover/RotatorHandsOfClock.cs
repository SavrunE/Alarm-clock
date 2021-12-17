using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RotatorHandsOfClock : MonoBehaviour
{
    public void DoRotate(HandOfClock handOfClock, int startAngle, int rotationAngle, float delayTime)
    {
        StartCoroutine(Rotator(handOfClock, startAngle, rotationAngle, delayTime));
    }

    private IEnumerator Rotator(HandOfClock handOfClock, int startAngle, int rotationAngle, float delayTime)
    {
        handOfClock.transform.Rotate(0f, 0f, startAngle);
        while (true)
        {
            yield return new WaitForSeconds(delayTime);

            startAngle -= rotationAngle;
            handOfClock.transform.DORotateQuaternion(Quaternion.Euler(0, 0, startAngle), 1f);
        }
    }
}
