using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GetTimeFromWebsite))]
public class TimeTaker : MonoBehaviour
{
    public int Hours { get; private set; }
    public int Minutes { get; private set; }
    public int Seconds { get; private set; }
    private string correctTime;
    private GetTimeFromWebsite getTimeFromWebsite;

    public Action OnTimeParsed;

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
        Hours = HMS[0];
        Minutes = HMS[1];
        Seconds = HMS[2];
        OnTimeParsed?.Invoke();
    }
}
