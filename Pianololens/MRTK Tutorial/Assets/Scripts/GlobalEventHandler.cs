using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalEventHandler : MonoBehaviour
{


    public static bool start = false;
    public static bool restart = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setStart()
    {
        start = true;
        restart = false;
    }

    public void setStop()
    {
        start = false;
    }

    public void setRestart()
    {
        start = false;
        restart = true;
    }

}
