using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GetTimeFromWebsite))]
public class TimeTaker : MonoBehaviour
{
    public int Hour { get; private set; }
    public int Minute { get; private set; }
    public int Second { get; private set; }
    private string correctTime;
    private GetTimeFromWebsite getTimeFromWebsite;

    public Action<TimeTaker> OnTimeParsed;

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
        Hour = HMS[0];
        Minute = HMS[1];
        Second = HMS[2];
        Debug.Log(Hour);
        Debug.Log(Minute);
        Debug.Log(Second);
        OnTimeParsed?.Invoke(this);
    }
}
