using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class GyroScopeReader
{
    public GyroScopeReader(float y)
    {
        yTreshHold = y;
    }

    [SerializeField]
    float yTreshHold = -0.0275f;

    /// <summary>
    /// Returns true if the phone is lying flat and false otherwise
    /// </summary>
    /// <returns></returns>
    public bool IsFlat()
    {
        if (Input.acceleration.y >= yTreshHold)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public Vector3 RecordAccelrometerValues()
    {
        return Input.acceleration;
    }
}
