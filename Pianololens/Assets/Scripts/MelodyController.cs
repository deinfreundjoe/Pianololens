using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;

public class MelodyController : MonoBehaviour
{

    private Vector3 CalibratedPos;
    private Quaternion CalibratedRot;

    public GameObject PianoReference;
    public GameObject HintCollection;
    public GameObject PianoKeys;
    public GameObject ChapterMenu;
    public GameObject Speedslider;

    private GameObject currentChapter;
    private int currentChapterIndex = 0;

    private int rightIndex = 0;
    private int leftIndex = 1;

    private bool rightHand = true;
    private bool leftHand = false;


    // Start is called before the first frame update
    
    void OnEnable()
    {
        EventManager.OnCalibrateAction += CalibratePosition;
        EventManager.OnChapterAction += ActivateChapter;
        EventManager.OnRightHandAction += ToggleRightHand;
        EventManager.OnLeftHandAction += ToggleLeftHand;
        EventManager.OnNextAction += NextChapter;
        EventManager.OnPrevAction += PrevChapter;
        EventManager.OnInitialAction += InitialChapter;
        EventManager.OnChapterEndAction += EnableChapterMenu;
    }

    void OnDisable()
    {
        EventManager.OnCalibrateAction -= CalibratePosition;
        EventManager.OnChapterAction -= ActivateChapter;
        EventManager.OnRightHandAction -= ToggleRightHand;
        EventManager.OnLeftHandAction -= ToggleLeftHand;
        EventManager.OnNextAction -= NextChapter;
        EventManager.OnPrevAction -= PrevChapter;
        EventManager.OnInitialAction -= InitialChapter;
        EventManager.OnChapterEndAction -= EnableChapterMenu;
    }

    public void CalibratePosition()
    {
        CalibratedPos = PianoReference.transform.position;
        CalibratedRot = PianoReference.transform.rotation;

        HintCollection.transform.position = CalibratedPos;
        HintCollection.transform.rotation = CalibratedRot;

        PianoKeys.transform.position = CalibratedPos;
        PianoKeys.transform.rotation = CalibratedRot;
    }

    public void ActivateChapter()
    {
        PianoKeys.gameObject.SetActive(true);
        HintCollection.gameObject.SetActive(true);

        foreach (Transform child in HintCollection.transform)
        {
            child.gameObject.SetActive(false);
        }

        currentChapter = HintCollection.transform.GetChild(currentChapterIndex).gameObject;
        currentChapter.SetActive(true);

        ActivateHandPart(currentChapter);

    }

    public void ActivateHandPart(GameObject currentChapter)
    {

        foreach (Transform child in currentChapter.transform)
        {
            child.gameObject.SetActive(false);
        }

        if (rightHand && !leftHand)
        {
            currentChapter.transform.GetChild(rightIndex).gameObject.SetActive(true);
            return;
        }

        if (leftHand && !rightHand)
        {
            currentChapter.transform.GetChild(leftIndex).gameObject.SetActive(true);
            return;
        }

        if (rightHand && leftHand)
        {
            currentChapter.transform.GetChild(rightIndex).gameObject.SetActive(true);
            currentChapter.transform.GetChild(leftIndex).gameObject.SetActive(true);  
            return;
        }
    }

    public void SetSpeedBySlider(SliderEventData eventData){
        Moving.speed = eventData.NewValue;
    }

    public void IncreaseSpeed()
    {
        if (Moving.speed < 1)
        {
            Moving.speed = Moving.speed + 0.1f;
        }
        Speedslider.GetComponent<PinchSlider>().SliderValue = Moving.speed;
    }

    public void DecreaseSpeed() { 
    
        if(Moving.speed > 0){
            Moving.speed = Moving.speed - 0.1f;
        }

        Speedslider.GetComponent<PinchSlider>().SliderValue = Moving.speed;
    }


    public void EnableChapterMenu()
    {

        HintCollection.SetActive(false);
        ChapterMenu.SetActive(true);
    }

    public void NextChapter()
    {
        if (currentChapterIndex < HintCollection.transform.childCount - 1)
        {
            currentChapterIndex++;
        }

    }

    public void PrevChapter()
    {
        if (currentChapterIndex > 0)
        {
            currentChapterIndex--;
        }

    }

    public void InitialChapter()
    {
        currentChapterIndex = 0;
    }

    public void ToggleRightHand()
    {
        if (!rightHand)
        {
            rightHand = true;
        }

        else
        {
            rightHand = false;
        }
    }

    public void ToggleLeftHand()
    {
        if (!leftHand)
        {
            leftHand = true;
        }

        else
        {
            leftHand = false;
        }
    }


}
