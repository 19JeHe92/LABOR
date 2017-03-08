using UnityEngine;
using NewtonVR;

public class CardFound : MonoBehaviour {

    public DoorButtonSoundManager hintManager;

    private NVRInteractableItem interactableItem;
    private bool isFound = false;

	void Awake()
    {
        interactableItem = GetComponent<PickableItem>();
    }

    void Update() {
        if (interactableItem.IsAttached)
        {
            if (!isFound)
            {
                hintManager.isCardFound = true;
                isFound = true;
            }
         }
	}
}
