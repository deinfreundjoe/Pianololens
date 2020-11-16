using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    private float speed = 0.5f;
    private Vector3 originalPos;

    // Start is called before the first frame update
    void Start()
    {
        originalPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalEventHandler.start)
        {
            gameObject.transform.position += gameObject.transform.forward * (speed * Time.deltaTime);
        }


        if (GlobalEventHandler.restart)
        {
            gameObject.transform.position = originalPos;
        }

    }

}
