using UnityEngine;
using NewtonVR;

//Alerts the hint manager that the card has been foun, so that the player does not get the hint anymore to find a card
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
