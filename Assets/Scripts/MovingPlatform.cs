using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Vector3 _start;
    [SerializeField] private Vector3 _end;
    [SerializeField] private float _compareDistanceValue;
    [SerializeField] float _maxDistanceDelta;

    private bool toEnd;
    
    private void Start()
    {
        transform.position = _start;
        toEnd = true;
    }
    void Update()
    {
        MoveBetweenPoints();
    }

    private void MoveBetweenPoints()
    {
        if(toEnd)
        {
            transform.position = Vector3.MoveTowards(transform.position, _end, _maxDistanceDelta *  Time.deltaTime);

            if(Vector3.Distance(transform.position, _end) < _compareDistanceValue)
            {
                toEnd = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _start, _maxDistanceDelta * Time.deltaTime);

            if(Vector3.Distance(transform.position, _start) < _compareDistanceValue)
            {
                toEnd = true;
            }
        }
    }
}
