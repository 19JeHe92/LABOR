using UnityEngine;
using UnityEngine.UI;
using NewtonVR;
using System;

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

	public void CheckInput()
    {
        string input = GetInput();
        if (input.Equals(solution1, StringComparison.InvariantCultureIgnoreCase))
        {
            sol1Light.active = true;
            capsule1.DisableZombie();
        }
        else if(input.Equals(solution2, StringComparison.InvariantCultureIgnoreCase))
        {
            sol2Light.active = true;
            capsule2.DisableZombie();
        }
        else if (input.Equals(solution3, StringComparison.InvariantCultureIgnoreCase))
        {
            sol3Light.active = true;
            capsule3.DisableZombie();
        }
        else if (input.Equals(solution4, StringComparison.InvariantCultureIgnoreCase))
        {
            sol4Light.active = true;
            capsule4.DisableZombie();
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
