using UnityEngine;
using NewtonVR;
using UnityEngine.SceneManagement;

public class RoboFloorLoader : MonoBehaviour {

    public bool isWeaponFound = false;
    public bool areAnagramsSolved = false;
    public AudioSource HintSound;

    private NVRButton button;

	void Awake()
    {
        button = GetComponent<NVRButton>();
    }
	
	void Update () {
        if (button.ButtonIsPushed)
        {
            if (isWeaponFound && areAnagramsSolved)
            {
                Debug.Log("Goodbye blue sky");
                SceneManager.LoadScene("ChP4-Smoke");
            }
            else if(!HintSound.isPlaying && !isWeaponFound)
            {
                HintSound.Play();
            }
        }
	}
}
