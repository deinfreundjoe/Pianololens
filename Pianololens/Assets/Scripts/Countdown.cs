using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class Countdown : MonoBehaviour
{
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

