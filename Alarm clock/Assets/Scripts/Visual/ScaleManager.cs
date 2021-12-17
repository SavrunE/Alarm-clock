using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleManager : MonoBehaviour
{
    [SerializeField] private float viewScale;
    public float ViewScale() => Camera.main.aspect * viewScale;
}
