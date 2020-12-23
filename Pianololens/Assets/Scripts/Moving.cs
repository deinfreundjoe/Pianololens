using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public static float speed = 0.1f;
    public bool playing;

    void OnEnable()
    {
        EventManager.OnStartAction += StartPlaying;
        EventManager.OnStopAction += StopPlaying;
    }

    void OnDisable()
    {
        EventManager.OnStartAction -= StartPlaying;
        EventManager.OnStopAction -= StopPlaying;
    }


    void FixedUpdate()
    {
        if (playing)
        {
            gameObject.transform.position -= gameObject.transform.forward * (speed * Time.deltaTime);
        }
    }


    public void StartPlaying()
    {
        playing = true;

    }

    public void StopPlaying()
    {
        playing = false;

    }

}
