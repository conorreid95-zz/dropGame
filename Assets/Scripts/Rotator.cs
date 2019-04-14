using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] float rotationSpeedPerSecond;
    public bool rotationEnabled = true;
    [SerializeField] Vector3 rotateAroundPoint;
    [SerializeField] Vector3 rotateDirection;
    
    // Update is called once per frame
    void Update()
    {
        if (rotationEnabled)
        {
            transform.RotateAround(rotateAroundPoint, rotateDirection, Time.deltaTime * rotationSpeedPerSecond);
        }
        else
        {

        }
    }
}
