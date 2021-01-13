using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChangeColor : MonoBehaviour
{

    /* This script is a small script to change the Render Color of the Holographic Piano Keys as soon as the Hint Collection Bars collide with them. 
     * This changing color visualizes which key the user needs to play at the moment. 
     */

    /* This is a special Layer which will be disregarded by the Changing color script. The End Chapter Gameobject has an invisible material on it. 
     * We don't want to make the Holograpic Piano Key invisible, if the End Chapter Gameobject collides with it.  
     */
    private int ChaperEndLayer = 10;

    private Material default_Material;
    private Material change_Material;
    private Renderer rend;

    public AudioClip note;
    AudioSource audioSource;

    void Start()
    {
        //Fetch the Default Material from the Renderer of the Holographic Piano Keys
        rend = gameObject.GetComponent<Renderer>();
        default_Material = rend.material;

        //Fetch the Piano Key sound which will be played as soon as the hint collides with the Holo Key
        audioSource = GetComponent<AudioSource>();
    }


    /*On Trigger Enter
     * Change the Material of the holographic key, to the material of the incoming colliding object - aka. make the key blue, or orange.
     * PlayOne Shot the attached Audio Piano Note. 
     */

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != ChaperEndLayer)
        {
            change_Material = other.gameObject.GetComponent<Renderer>().material;
            rend.material = change_Material;
            audioSource.PlayOneShot(note);
        }

    }
    
    /* OnTrigger Exit
     * Change Material back to the default Holo Key material
     * Set the collided GameObject (incoming Hint) inactive. This will be again be reenabled by the EnableRender.cs script  
     */

    private void OnTriggerExit(Collider other)
    {
        rend.material = default_Material;
        other.gameObject.SetActive(false);
    }
}
