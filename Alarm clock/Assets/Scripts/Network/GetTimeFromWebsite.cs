using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Net.Http;
using System;

public class GetTimeFromWebsite : MonoBehaviour
{
    private string strTimeDCM;
    private bool canFindNextSite;

    private string urlLinkTochnoeMoskovskoeVremya = "https://tochnoe-moskovskoe-vremya.ru/vremya/moscow";
    private string urlLinkUnnRu = "http://www.unn.ru/time/";

    public void GetDataTochnoeMoskovskoeVremya() => TakeTimeUWR(urlLinkTochnoeMoskovskoeVremya,
       new string[] {
        "dclock__number dclock__hours", "<span",
        "dclock__number dclock__minutes", "<span" ,
        "dclock__number dclock__seconds", "<span" ,
       });
    public void GetDataUnnRu() => TakeTimeUWR(urlLinkUnnRu,
       new string[] { "servertime", "/div" });

    public Action<string> OnTimeChanged;

    private void Start()
    {
        FindTime();
    }

    public void FindTime()
    {
        canFindNextSite = true;
        GetDataTochnoeMoskovskoeVremya();
    }

    private void TryFindNextWebsite()
    {
        if (canFindNextSite)
        {
            canFindNextSite = false;
            GetDataUnnRu();
        }
        else
        {
            Debug.Log("Have no info from websites");
        }
    }

    private bool CheckCorrectTime(string strTime)
    {
        if (strTime.Length == 6)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void TakeTimeUWR(string urlLink, string[] betweenValues)
    {
        StartCoroutine(GetData_Coroutine(urlLink, betweenValues));
    }


    private IEnumerator GetData_Coroutine(string urlLink, string[] betweenValues)
    {
        Debug.Log("Loading time...");

        using (UnityWebRequest request = UnityWebRequest.Get(urlLink))
        {
            yield return request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError)
            {
                Debug.Log("Error NetworkError");
            }
            else
            {
                string cutString = request.downloadHandler.text;
                FindBetweenValues(betweenValues, cutString);
            }
        }
    }

    private void FindBetweenValues(string[] betweenValues, string cutString)
    {
        if (betweenValues.Length != 0 && betweenValues.Length % 2 == 0)
        {
            string endString = "";
            for (int i = 0; i < betweenValues.Length; i += 2)
            {
                string value = GetBetween(cutString, betweenValues[i], betweenValues[i + 1]);
                value = GetBetween(value, ">", "<");
                value = CutColon(value);

                endString += value;
            }

            if (CheckCorrectTime(endString))
            {
                strTimeDCM = endString;
                OnTimeChanged?.Invoke(strTimeDCM);
            }
            else
            {
                TryFindNextWebsite();
            }
        }
        else
        {
            Debug.Log(betweenValues.Length + " must contain even numbers");
        }
    }


    private string GetBetween(string strSource, string strStart, string strEnd)
    {
        if (strSource.Contains(strStart) && strSource.Contains(strEnd))
        {
            int Start, End;
            Start = strSource.IndexOf(strStart, 0) + strStart.Length;
            End = strSource.IndexOf(strEnd, Start);
            return strSource.Substring(Start, End - Start);
        }

        return "";
    }

    private string CutColon(string strSource)
    {
        return strSource.Replace(":", string.Empty);
    }
}
