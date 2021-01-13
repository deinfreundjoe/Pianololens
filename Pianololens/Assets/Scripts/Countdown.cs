using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class Countdown : MonoBehaviour
{

    /* This is a script for handling the Countdown which is shown right before the hints start to move in.
     * The Counter is again listening to an event by the EventManager.
     */

    private float timeLeft = 5f;
    private bool EnableCounter = false;
    public UnityEvent countdownZero;


    void OnEnable()
    {
        EventManager.OnCountdownAction += StartCountDown;
    }

    void OnDisable()
    {
        EventManager.OnCountdownAction -= StartCountDown;
    }

    public void StartCountDown()
    {
        EnableCounter = true;
        timeLeft = 5f;
    }

    // Maybe not the most elegant way to programm this countdown via an Update loop, but I found no real alternative solution. 
    //Basically it is just decreasing the timeLeft variable over time and displaying its value in as TextMeshPro Object. 

    void Update()
    {
        if (EnableCounter)
        {
            timeLeft -= Time.deltaTime;
            gameObject.GetComponent<TextMeshProUGUI>().text = (timeLeft).ToString("0");
            if (timeLeft < 0)
            {
                EnableCounter = false;
                countdownZero.Invoke();
            }
        }
    }
}

