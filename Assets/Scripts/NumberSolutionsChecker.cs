using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NewtonVR;
using UnityEngine.UI;
using System;

public class NumberSolutionsChecker : MonoBehaviour
{

    public int solution1;
    public int solution2;
    public int solution3;
    public int solution4;

    public DisplayManager display;
   // public PinkPuzzle puzzle;

    public GameObject sol1Light;
    public GameObject sol2Light;
    public GameObject sol3Light;
    public GameObject sol4Light;

    public NVRButton button;

    public AudioSource wrongAudio;
    public AudioSource correctAudio;

    void Update()
    {
        if (button.ButtonDown)
            CheckInput();
    }

    public void CheckInput()
    {
        int input = GetInput();
        if (solution1 == input)
        {
            sol1Light.active = true;
            correctAudio.Play();
        }
        else if (solution2 == input)
        {
            sol2Light.active = true;
            correctAudio.Play();
        }
        else if (solution3 == input)
        {
            sol3Light.active = true;
            correctAudio.Play();
        }
        else if (solution4 == input)
        {
            sol4Light.active = true;
            correctAudio.Play();
        }
        else
        {
            wrongAudio.Play();
        }
        if (sol1Light.active && sol2Light.active && sol3Light.active && sol4Light.active)
        {
         //   puzzle.solved = true;
        }
        display.ClearDisplay();
    }

    private int GetInput()
    {
        string enteredChars = "";
        foreach (Text character in display.chars)
        {
            enteredChars += character.text;
        }

        return Int32.Parse(enteredChars);
    }
}
