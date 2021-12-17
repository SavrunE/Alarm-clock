using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignCircle : MonoBehaviour
{
    [SerializeField] private Number[] numbers;
    [SerializeField] private float viewDistance = 2;
    private float viewDistanceParameter;
    private float Angle = 360;
    private int count = 12;

    void Start()
    {
        viewDistanceParameter = Camera.main.aspect* viewDistance;

        Vector3 point = transform.position;
        Angle = Angle * Mathf.Deg2Rad;
        for (int i = 0; i < count; i++)
        {
            float y = transform.position.z + Mathf.Cos(Angle / count * i) * viewDistanceParameter;
            float x = transform.position.x + Mathf.Sin(Angle / count * i) * viewDistanceParameter;
            point.x = x;
            point.y = y;
            numbers[i].transform.localPosition = point;
        }
    }
}
