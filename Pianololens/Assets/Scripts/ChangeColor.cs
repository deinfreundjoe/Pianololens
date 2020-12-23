using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChangeColor : MonoBehaviour
{
    private int ChaperEndLayer = 10;

    private Material default_Material;
    private Material change_Material;
    private Renderer rend;

    public AudioClip note;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        //Fetch the Material from the Renderer of the GameObject
        rend = gameObject.GetComponent<Renderer>();
        default_Material = rend.material;
        audioSource = GetComponent<AudioSource>();
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != ChaperEndLayer)
        {
            change_Material = other.gameObject.GetComponent<Renderer>().material;
            rend.material = change_Material;
            audioSource.PlayOneShot(note);
        }

    }
    

    private void OnTriggerExit(Collider other)
    {
        rend.material = default_Material;
        other.gameObject.GetComponent<MeshRenderer>().enabled = false;
    }
}
