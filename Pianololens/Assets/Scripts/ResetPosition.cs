using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPosition : MonoBehaviour
{

    // This is just a small script to reposition certain elements as soon as the RestPosition event occurs by the EventManager. E.g. the HintCollection Chapter Gameobjects or the PianoReference Calibration Cube use this script. 
    private Vector3 originalPosition;
    private Quaternion originalRotation;

    void OnEnable()
    {
        EventManager.OnResetAction += Reposition;
    }

    void OnDisable()
    {
        EventManager.OnResetAction -= Reposition;
    }

    // Fetching the original position of the Gameobject, as soon as they get activated. 
    void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    // Reposition the Gameobject to their original position if the ResetPosition event by the EventManager occurs. 
    public void Reposition()
    {
        transform.position = originalPosition;
        transform.rotation = originalRotation;
    }
}
