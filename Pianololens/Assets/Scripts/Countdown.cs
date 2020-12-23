using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class Countdown : MonoBehaviour
{
    private int countdownTime = 5;
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
        countdownTime = 5;
        StartCoroutine("StartCountDownNow");
    }



    IEnumerator StartCountDownNow()
    {
        while (countdownTime > 0)
        {
            gameObject.GetComponent<TextMeshProUGUI>().text = countdownTime.ToString();

            yield return new WaitForSeconds(1f);

            countdownTime--;
        }

        gameObject.GetComponent<TextMeshProUGUI>().text = "Go!";

        yield return new WaitForSeconds(1f);

        countdownZero.Invoke();
    }
}

