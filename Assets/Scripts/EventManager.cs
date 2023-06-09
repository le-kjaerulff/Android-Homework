using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void PhoneState();
    public static event PhoneState IsFlat;
    public static event PhoneState IsNotFlat;

    public delegate void RecState();
    public static event RecState StartRec;
    public static event RecState Recording;
    public static event RecState StopRec;

    [SerializeField]
    float yLowerThresHold = -0.02f;
    [SerializeField]
    float yUpperThreshold = -0.005f;
    bool recordInputs = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Flat() && IsFlat != null)
        {
            IsFlat();
        }
        else if (IsNotFlat != null)
        {
            IsNotFlat();
        }

        if(recordInputs && !Flat())
        {
            Recording();
        }
        else if(recordInputs && Flat())
        {
            StopRec();
            recordInputs = false;
        }
    }

    public void ButtonPressAlt()
    {
        if (recordInputs == false)
        {
            StartRec();
            recordInputs = true;
        }
    }

    public bool Flat()
    {
        if (Input.acceleration.y >= yLowerThresHold && Input.acceleration.y <= yUpperThreshold)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
