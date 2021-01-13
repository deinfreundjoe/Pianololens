using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{

    /*This script is enabling and disabling the movement of the hint bars. As soon as the EventManager invokes the event, the hints either start moving into the users direction or stop moving. 
     * The speed of the movement is adjustable by the slider in the HandMenu.
     */

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

    // if playing is true, the hint bars start moving into the direction of the user. 
    void FixedUpdate()
    {
        if (playing)
        {
            gameObject.transform.position -= gameObject.transform.forward * (speed * Time.deltaTime);
        }
    }

    // These methods simply set playing bool true or false, as soon as the event occurs. 
    public void StartPlaying()
    {
        playing = true;

    }

    public void StopPlaying()
    {
        playing = false;

    }

}
