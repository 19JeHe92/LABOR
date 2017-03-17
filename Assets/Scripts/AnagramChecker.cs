using UnityEngine;
using UnityEngine.UI;
using NewtonVR;

//Checks if the Anagrams is the ZombieLab are solved
//If tthe time is up, the Zombies are released from their Capsules
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

    public void StartGame()
    {
        //TODO Play Ticking Sound
        capsule1.isStarted = true;
        capsule2.isStarted = true;
        capsule3.isStarted = true;
        capsule4.isStarted = true;
    }

    void Update()
    {
        //If the anagrams are not solved play the c'mon sound periodically
        if (!sol1Light.active || !sol2Light.active || !sol3Light.active || !sol4Light.active)
        {
            counter += Time.deltaTime;
            if (counter > secondsBetweenCmon)
            {
                comeonAudio.Play();
                counter = 0;
            }
        }

        //If an anagram is solved disable one zombie
        if (capsule1.isReleased)
        {
            sol1Light.active = true;
            capsule1.DisableZombie();
        }
        if (capsule2.isReleased)
        {
            sol2Light.active = true;
            capsule2.DisableZombie();
        }
        if (capsule3.isReleased)
        {
            sol3Light.active = true;
            capsule3.DisableZombie();
        }
        if (capsule4.isReleased)
        {
            sol4Light.active = true;
            capsule4.DisableZombie();
        }
        if (button.ButtonDown)
            CheckInput();
    }

    //Check if the entered Text solves one of the Anagrams
	public void CheckInput()
    {
        string input = GetInput();
        //Debug.Log("Anagram Input: "+input +" "+ string.Compare(solution1, input, true));
        if (string.Compare(solution1, input, true)==0 && !sol1Light.active)
        {
            // Debug.Log("Anagram 1 solved");
            ResolveAnagram( capsule1, sol1Light);
        }
        else if(string.Compare(solution2, input, true) == 0 && !sol2Light.active)
        {
            // Debug.Log("Anagram 2 solved");
            ResolveAnagram(capsule2, sol2Light);
        }
        else if (string.Compare(solution3, input, true) == 0 && !sol3Light.active)
        {
            // Debug.Log("Anagram 3 solved");
            ResolveAnagram(capsule3, sol3Light);
        }
        else if (string.Compare(solution4, input, true) == 0 && !sol4Light.active)
        {
            //Debug.Log("Anagram 4 solved");
            ResolveAnagram(capsule4, sol4Light);
        }
        else
        {
            wrongAudio.Play();
        }
        if (sol1Light.active && sol2Light.active && sol3Light.active && sol4Light.active)
        {
            floorLoader.areAnagramsSolved = true;
        }
        display.ClearDisplay();
    }

    //Returns the characters input from the display
    private string GetInput()
    {
        string enteredChars = "";
        foreach (Text character in display.chars)
        {
            enteredChars += character.text;
        }
        return enteredChars;
    }

    private void ResolveAnagram(ZombieCapsuleController zombieCapsule, GameObject light)
    {
        light.active = true;
        zombieCapsule.DisableZombie();
        correctAudio.Play();
    }
}
