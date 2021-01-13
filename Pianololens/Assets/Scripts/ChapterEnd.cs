using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChapterEnd : MonoBehaviour
{
    /* This is just a small script which is attched to the invisible Chapter End Gameobject in the moving Hint Collections.
     * As soon as the Chapter End Object collides with the holographic Piano, the the onChapterEnd event get's invoked, which starts up the Chapter End Menu. 
     */

    [SerializeField]
    private UnityEvent onChapterEnd;

    private void OnTriggerEnter(Collider other)
    {
        onChapterEnd.Invoke();
    }
}
