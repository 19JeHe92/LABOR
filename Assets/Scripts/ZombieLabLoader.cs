using UnityEngine;
using NewtonVR;
using UnityEngine.SceneManagement;

public class ZombieLabLoader : MonoBehaviour {

    public NVRButton button;
    private NVRAttachPoint card;
	
	void Awake () {
        card = GetComponent<NVRAttachPoint>();
	}
	
	void Update () {
        if (card.IsAttached && button.ButtonDown)
        {
            SceneManager.LoadScene("ChP2-ZombieLab");
        }	
	}
}
