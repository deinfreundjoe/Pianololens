using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableRender : MonoBehaviour
{

    /* This is only a small script which reactivate the moving Hint Collection Gameobjects. The bars collide with the holographic piano. 
     * As soon as the bars exit the collision, the gameobject gets diabled. This is only a small script to reactivate the Gameobject, for example if the chapter will be restarted.
     * This is again called by an event from the EventManager.
     */

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
