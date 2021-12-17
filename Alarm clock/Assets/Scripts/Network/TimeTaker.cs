using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GetTimeFromWebsite))]
public class TimeTaker : MonoBehaviour
{
    private int hour;
    private int minute;
    private int second;
    private string correctTime;
    private GetTimeFromWebsite getTimeFromWebsite;

    private void OnEnable()
    {
        getTimeFromWebsite = GetComponent<GetTimeFromWebsite>();
        getTimeFromWebsite.OnTimeChanged += ChangeTime;
    }
    private void OnDisable()
    {
        getTimeFromWebsite.OnTimeChanged -= ChangeTime;
    }

    private void ChangeTime(string strTime)
    {
        correctTime = strTime;
        Debug.Log(correctTime);

        TimeParser();
    }

    private void TimeParser()
    {
        int i = 0;
        int HMSnumerator = 0;
        int[] HMS = new int[3];
        while (i < correctTime.Length)
        {
            string substring = correctTime.Substring(i, 2);
            HMS[HMSnumerator++] = int.Parse(substring);
            i += 2;
        }
        hour = HMS[0];
        minute = HMS[1];
        second = HMS[2];
        Debug.Log(hour);
        Debug.Log(minute);
        Debug.Log(second);
    }
}
