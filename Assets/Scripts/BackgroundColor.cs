using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BackgroundColor : MonoBehaviour
{
    private void OnEnable()
    {
        EventManager.IsFlat += TurnGreen;
        EventManager.IsNotFlat += TurnRed;
    }
    private void OnDisable()
    {
        EventManager.IsFlat -= TurnGreen;
        EventManager.IsNotFlat -= TurnRed;
    }

    void TurnGreen()
    {
        this.GetComponent<Image>().color = Color.green;
    }

    void TurnRed()
    {
        this.GetComponent<Image>().color = Color.red;
    }
}
