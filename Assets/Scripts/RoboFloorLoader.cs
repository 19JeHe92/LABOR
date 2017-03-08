using UnityEngine;
using NewtonVR;
using UnityEngine.SceneManagement;

public class RoboFloorLoader : MonoBehaviour {

    private NVRButton button;

	void Awake()
    {
        button = GetComponent<NVRButton>();
    }
	
	void Update () {
        if (button.ButtonIsPushed)
        {
            Debug.Log("Goodbye blue sky");
            SceneManager.LoadScene("ChP3-RoboFloor");
        }
	}
}
