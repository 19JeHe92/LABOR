using UnityEngine;
using NewtonVR;
using UnityEngine.UI;

[RequireComponent(typeof(NVRHand))]
public class InventoryController : MonoBehaviour
{
    public NVRButtons PickUpButton = NVRButtons.Trigger;
    public NVRButtons ShowInventoryButton = NVRButtons.ApplicationMenu;
    public GameObject InventoryObject;
    public Text knivesAmountText;
    public Text medicineAmountText;
    public Text bombsAmountText;
    public Text cardsAmountText;
    public Text weaponsAmountText;
    public Text injectionsAmountText;

    private NVRHand connectedHand;
    private AudioSource inventorySound;
    private int knivesAmount = 0;
    private int medicineAmount = 0;
    private int bombsAmount = 0;
    private int cardsAmount = 0;
    private int weaponsAmount = 0;
    private int injectionsAmount = 0;

    void Awake()
    {
        connectedHand = this.GetComponent<NVRHand>();
        inventorySound = GetComponent<AudioSource>();
    }

    private void LateUpdate()
    {
        if (connectedHand.Inputs[PickUpButton].PressDown == true)
        {
            Debug.Log("Pickup");
            PickupClosest();
        }
        if (connectedHand.Inputs[ShowInventoryButton].PressDown == true)
        {
            Debug.Log("Call/Hide inventory");
            if (!InventoryObject.active)
            {
                InventoryObject.SetActive(true);
                InventoryObject.transform.position = connectedHand.transform.position;
                InventoryObject.transform.rotation = connectedHand.transform.rotation;
            }
            else
            {
                InventoryObject.SetActive(false);
            }
        }
    }

    private bool PickupClosest()
    {
        PickableItem closest = null;
        float closestDistance = float.MaxValue;

        foreach (var hovering in connectedHand.CurrentlyHoveringOver)
        {
            if (hovering.Key == null)
                continue;

            float distance = Vector3.Distance(this.transform.position, hovering.Key.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                if(hovering.Key.GetType() == typeof(PickableItem))
                    closest = (PickableItem)hovering.Key;
            }
        }

        if (closest != null)
        {
            connectedHand.EndInteraction(closest);
            AddToInventory(closest);
            inventorySound.Play();
            return true;
        }
        else
        {
            return false;
        }
    }

    private void AddToInventory(PickableItem item)
    {
        //check which object type was picked
        //add to inventory
        switch (item.objectType)
        {
            case InventoryObjectType.Knife :
                Debug.Log("Knife added to inventory");
                knivesAmount++;
                knivesAmountText.text = knivesAmount.ToString();
                break;
            case InventoryObjectType.Injection:
                Debug.Log("Injection added to inventory");
                injectionsAmount++;
                injectionsAmountText.text = injectionsAmount.ToString();
                break;
            case InventoryObjectType.Medicine:
                Debug.Log("Medicine added to inventory");
                medicineAmount++;
                medicineAmountText.text = medicineAmount.ToString();
                break;
            case InventoryObjectType.Weapon:
                Debug.Log("Weapon added to inventory");
                weaponsAmount++;
                weaponsAmountText.text = weaponsAmount.ToString();
                break;
            case InventoryObjectType.Bomb:
                Debug.Log("Bomb added to inventory");
                bombsAmount++;
                bombsAmountText.text = bombsAmount.ToString();
                break;
            case InventoryObjectType.Card:
                Debug.Log("Card added to inventory");
                cardsAmount++;
                cardsAmountText.text = cardsAmount.ToString();
                break;
        }
        item.gameObject.SetActive(false);
    }

    public bool RemovefromInventory(InventoryObjectType item)
    {
        bool success = false;
        switch (item)
        {
            case InventoryObjectType.Knife:
                if(knivesAmount > 0)
                {
                    Debug.Log("Knife removed from inventory");
                    knivesAmount--;
                    knivesAmountText.text = knivesAmount.ToString();
                    success = true;
                }
                break;
            case InventoryObjectType.Injection:
                if (injectionsAmount > 0)
                {
                    Debug.Log("Injection removed from inventory");
                    injectionsAmount--;
                    injectionsAmountText.text = injectionsAmount.ToString();
                    success = true;
                }
                break;
            case InventoryObjectType.Medicine:
                if (medicineAmount > 0)
                {
                    Debug.Log("Medicine removed from inventory");
                    medicineAmount--;
                    medicineAmountText.text = medicineAmount.ToString();
                    success = true;
                }
                break;
            case InventoryObjectType.Weapon:
                if(weaponsAmount > 0)
                {
                    Debug.Log("Weapon removed from inventory");
                    weaponsAmount--;
                    weaponsAmountText.text = weaponsAmount.ToString();
                    success = true;
                }
                break;
            case InventoryObjectType.Bomb:
                if(bombsAmount > 0)
                {
                    Debug.Log("Bomb removed from inventory");
                    bombsAmount--;
                    bombsAmountText.text = bombsAmount.ToString();
                    success = true;
                }
                break;
            case InventoryObjectType.Card:
                if(cardsAmount > 0)
                {
                    Debug.Log("Card removed from inventory");
                    cardsAmount++;
                    cardsAmountText.text = cardsAmount.ToString();
                    success = true;
                }
                break;
        }
        return success;
    }
}
