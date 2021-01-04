using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableRender : MonoBehaviour
{

    void OnEnable()
    {
        EventManager.OnRenderAction += EnableRenderer;
    }

    void OnDisable()
    {
        EventManager.OnRenderAction -= EnableRenderer;
    }

    public void EnableRenderer()
    {
        foreach (Transform child in gameObject.transform)
        {
            child.gameObject.SetActive(true);
        }
    }
}
