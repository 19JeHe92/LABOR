using UnityEngine;
using UnityEngine.UI;
using System;
using NewtonVR;

public class AnagramChecker : MonoBehaviour {

    public string solution1;
    public string solution2;
    public string solution3;
    public string solution4;

    public GameObject sol1Light;
    public GameObject sol2Light;
    public GameObject sol3Light;
    public GameObject sol4Light;

    public ZombieCapsuleController capsule1;
    public ZombieCapsuleController capsule2;
    public ZombieCapsuleController capsule3;
    public ZombieCapsuleController capsule4;

    public DisplayManager display;
    public RoboFloorLoader floorLoader;

    public AudioSource wrongAudio;
    public AudioSource correctAudio;
    public AudioSource comeonAudio;
    public float secondsBetweenCmon = 60f;

    private NVRButton button;
    private float counter = 0;

    void Awake()
    {
        button = GetComponent<NVRButton>();
    }

    void Update()
    {
        if (!sol1Light.active || !sol2Light.active || !sol3Light.active || !sol4Light.active)
        {
            counter += Time.deltaTime;
            if (counter > secondsBetweenCmon)
            {
                comeonAudio.Play();
                counter = 0;
            }
        }

        if (capsule1.isReleased)
        {
            sol1Light.active = true;
        }
        if (capsule2.isReleased)
        {
            sol2Light.active = true;
        }
        if (capsule3.isReleased)
        {
            sol3Light.active = true;
        }
        if (capsule4.isReleased)
        {
            sol4Light.active = true;
        }
        if (button.ButtonDown)
            CheckInput();
    }

	public void CheckInput()
    {
        string input = GetInput();
        Debug.Log("Anagram Input: "+input +" "+ string.Compare(solution1, input, true));
        if (string.Compare(solution1, input, true)==0 && !sol1Light.active)
        {
            Debug.Log("Anagram 1 solved");
            sol1Light.active = true;
            capsule1.DisableZombie();
            correctAudio.Play();
        }
        else if(string.Compare(solution2, input, true) == 0 && !sol2Light.active)
        {
            Debug.Log("Anagram 2 solved");
            sol2Light.active = true;
            capsule2.DisableZombie();
            correctAudio.Play();
        }
        else if (string.Compare(solution3, input, true) == 0 && !sol3Light.active)
        {
            Debug.Log("Anagram 3 solved");
            sol3Light.active = true;
            capsule3.DisableZombie();
            correctAudio.Play();
        }
        else if (string.Compare(solution4, input, true) == 0 && !sol4Light.active)
        {
            Debug.Log("Anagram 4 solved");
            sol4Light.active = true;
            capsule4.DisableZombie();
            correctAudio.Play();
        }
        else
        {
            wrongAudio.Play();
        }
        if (sol1Light.active && sol2Light.active && sol3Light.active && sol4Light.active)
        {
            floorLoader.areAnagramsSolved = true;
        }
    }

    private string GetInput()
    {
        string enteredChars = "";
        foreach (Text character in display.chars)
        {
            enteredChars += character.text;
        }
        return enteredChars;
    }
}
