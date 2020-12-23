using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChapterEnd : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onChapterEnd;

    private void OnTriggerEnter(Collider other)
    {
        onChapterEnd.Invoke();
    }
}
