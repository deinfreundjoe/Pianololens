using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPosition : MonoBehaviour
{
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

    void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    public void Reposition()
    {
        transform.position = originalPosition;
        transform.rotation = originalRotation;
    }
}
