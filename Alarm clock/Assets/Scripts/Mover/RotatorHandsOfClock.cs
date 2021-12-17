using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RotatorHandsOfClock : MonoBehaviour
{
    private Dictionary<HandOfClock, Coroutine> activeCoroutine;

    private void OnEnable()
    {
        activeCoroutine = new Dictionary<HandOfClock, Coroutine>();
    }

    public void DoRotate(HandOfClock handOfClock, int startAngle, int rotationAngle, float delayTime)
    {
        Coroutine coroutine = StartCoroutine(Rotator(handOfClock, startAngle, rotationAngle, delayTime));
        
        activeCoroutine.Add(handOfClock, coroutine);
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

    public void StopRotate(HandOfClock handOfClock)
    {
        if (activeCoroutine.ContainsKey(handOfClock))
        {
            StopCoroutine(activeCoroutine[handOfClock]);
            activeCoroutine.Remove(handOfClock);
        }
    }
}
