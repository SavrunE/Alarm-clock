using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmScale : MonoBehaviour
{
    [SerializeField] private ScaleManager scaleManager;

    private void Start()
    {
        transform.localScale *= scaleManager.ViewScale();
    }
}
