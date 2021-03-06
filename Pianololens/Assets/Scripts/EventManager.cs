﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{


    /* With this project I wanted to take an approach I've never done before. Instead of having public methods which get called from a controller object directly, I wanted to try handling the logic via this EventManager.
     * Basically this EventManager introduces events for the major functions that happen in the application. These events are mostly invoked by the MRTK Interactable Component which is attached to the buttons.
     * The MelodyController.cs is listening to these events and is then performing the representative method.
     * This Eventhandler.cs script is therefore only setting up the event delegates and defining the public methods which will invoke the event as soon as the button was clicked. 
    */



    public delegate void SetChapter();
    public static event SetChapter OnChapterAction;

    public delegate void StartAction();
    public static event StartAction OnStartAction;

    public delegate void StopAction();
    public static event StartAction OnStopAction;

    public delegate void Calibrate();
    public static event Calibrate OnCalibrateAction;

    public delegate void ResetPosition();
    public static event ResetPosition OnResetAction;

    public delegate void RightHand();
    public static event RightHand OnRightHandAction;

    public delegate void LeftHand();
    public static event LeftHand OnLeftHandAction;

    public delegate void SliderValue();
    public static event SliderValue OnSliderAction;

    public delegate void NextChapter();
    public static event NextChapter OnNextAction;

    public delegate void PrevChapter();
    public static event PrevChapter OnPrevAction;

    public delegate void InitialChapter();
    public static event InitialChapter OnInitialAction;

    public delegate void ChapterEnd();
    public static event ChapterEnd OnChapterEndAction;

    public delegate void EnableRend();
    public static event EnableRend OnRenderAction;

    public delegate void StartCountdown();
    public static event StartCountdown OnCountdownAction;
    public void OnCalibrateKeys()
    {
        if (OnCalibrateAction != null)
        {
            OnCalibrateAction();
        }
    }

    public void OnStartPlay()
    {
        if (OnStartAction != null)
        {
            OnStartAction();
        }
    }

    public void OnStopPlay()
    {
        if (OnStopAction != null)
        {
            OnStopAction();
        }
    }

    public void OnResetPosition()
    {
        if (OnResetAction != null)
        {
            OnResetAction();
        }
    }

    public void OnSetChapter()
    {
        if (OnChapterAction != null)
        {
            OnChapterAction();
        }
    }

    public void OnRightHand()
    {
        if (OnRightHandAction != null)
        {
            OnRightHandAction();
        }
    }

    public void OnLeftHand()
    {
        if (OnLeftHandAction != null)
        {
            OnLeftHandAction();
        }
    }

    public void OnSliderUpdated()
    {
        if (OnSliderAction != null)
        {
            OnSliderAction();
        }
    }

    public void OnNextChaper()
    {
        if (OnNextAction != null)
        {
            OnNextAction();
        }
    }

    public void OnPrevChapter()
    {
        if (OnPrevAction != null)
        {
            OnPrevAction();
        }
    }

    public void OnInitialChapter()
    {
        if (OnInitialAction != null)
        {
            OnInitialAction();
        }
    }

    public void OnCountdown()
    {
        if (OnCountdownAction != null)
        {
            OnCountdownAction();
        }
    }

    public void OnChapterEnd()
    {
        if (OnChapterEndAction != null)
        {
            OnChapterEndAction();
        }
    }

    public void OnRenderEnable()
    {
        if (OnRenderAction != null)
        {
            OnRenderAction();
        }
    }

}
