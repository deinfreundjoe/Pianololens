using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;

public class MelodyController : MonoBehaviour
{

    /* This is the Controller. It handles all the methods of the whole appllication.
     * The Controller is listening to the events of the EventManager and executes the methods as soon as the event occur. This way, I was able to seperate the methods, from the Unity Editor. 
     * Inside of the Editor I was only invoking the events by the EventManager and the Controller then executes the method that I have linked to them here inside of the MelodyController.cs script
     */

    //just some SerialzedFields I needed to access some Gameobjects directly here in the script
    [SerializeField]
    private GameObject PianoReference;
    [SerializeField]
    private GameObject HintCollection;
    [SerializeField]
    private GameObject PianoKeys;
    [SerializeField]
    private GameObject ChapterMenu;
    [SerializeField]
    private GameObject StartPlayButton;

    // Handling the logic behind which chapter should be active.
    private GameObject currentChapter;
    private int currentChapterIndex = 0;

    // Used for the Calibration of the piano and setting the melody content according to the positioning of the Initial Calibration Piano Cube.
    private Vector3 CalibratedPos;
    private Quaternion CalibratedRot;

    // only indicating that the RightHand Hints are always at index 0, and the LeftHand Hints at index 1 as childs of the Chapter Gameobjects.   
    private int rightIndex = 0;
    private int leftIndex = 1;

    // only used to set the RightHand Hints active as soon as the user selected which hands he/she wants to play.
    private bool rightHand = true;
    private bool leftHand = false;

    //Registering/Deregistering the methods to the events by the EventHandler
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

    //Method to calibrate the position of the Piano. The PianoReference Calibration Cube indicates where the the Hintcollections as well as the Holographic piano should be placed.
    //This way the incoming hints will always be perfectly aligned with the real physical piano at the desk.  
    private void CalibratePosition()
    {
        CalibratedPos = PianoReference.transform.position;
        CalibratedRot = PianoReference.transform.rotation;

        HintCollection.transform.position = CalibratedPos;
        HintCollection.transform.rotation = CalibratedRot;

        PianoKeys.transform.position = CalibratedPos;
        PianoKeys.transform.rotation = CalibratedRot;
    }

    // Method which activates the chapter. First it sets all childs inactive, to then choose which chapter and hand part to set active according to the input by the user. 
    private void ActivateChapter()
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

    // Method to distinguish which hand is activated by the user and then set the respective hand part active. 
    private void ActivateHandPart(GameObject currentChapter)
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

    // Method which will be called as soon as the user changes the slider speed in the HandMenu. Simply taking the new value eventData of the adjusted slider and matching the hint Moving.speed according to the new value. 
    private void SetSpeedBySlider(SliderEventData eventData){
        Moving.speed = eventData.NewValue;
    }

    // Method which enables the ChapterMenu, after one chapter was finished. This method will be invoked by the ChapterEnd Gameobject as soon as it collides with the Holographic piano. 
    private void EnableChapterMenu()
    {
        HintCollection.SetActive(false);
        ChapterMenu.SetActive(true);
    }

    // Method to go to the next Chapter. simply increasing the currentChapter index and then calling the ActivateChapter(), which will then activate the next chapter if possible. 
    private void NextChapter()
    {
        if (currentChapterIndex < HintCollection.transform.childCount - 1)
        {
            currentChapterIndex++;
        }

        ActivateChapter();

    }

    // Method to go to the previous Chapter. simply decreasing the currentChapter index and then calling the ActivateChapter(), which will then activate the previous chapter if possible. 
    private void PrevChapter()
    {
        if (currentChapterIndex > 0)
        {
            currentChapterIndex--;
        }

        ActivateChapter();
    }

    // Setting the current Chapter again to the inital state. E.g. when going back home. 
    private void InitialChapter()
    {
        currentChapterIndex = 0;
    }

    // Toggling the bool for the RightHand. This will be changed by the toggle buttons in the Choose Hands Menu.
    private void ToggleRightHand()
    {
        if (!rightHand)
        {
            rightHand = true;
        }

        else
        {
            rightHand = false;
        }

        CheckHandSelection();
    }

    // Toggling the bool for the LefhHand. This will be changed by the toggle Bbttons in the Choose Hands Menu.
    private void ToggleLeftHand()
    {
        if (!leftHand)
        {
            leftHand = true;
        }

        else
        {
            leftHand = false;
        }

        CheckHandSelection();
    }

    // Helper method the disable the StartPlay Button in the Choose Hands Menu, if no hand was selected.
    private void CheckHandSelection()
    {
        if (!rightHand && !leftHand)
        {
            StartPlayButton.GetComponent<Interactable>().enabled = false;
            StartPlayButton.GetComponent<PressableButtonHoloLens2>().enabled = false;
        }

        else
        {
            StartPlayButton.GetComponent<Interactable>().enabled = true;
            StartPlayButton.GetComponent<PressableButtonHoloLens2>().enabled = true;
        }
    }

}
