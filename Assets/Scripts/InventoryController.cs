using UnityEngine;
using NewtonVR;

[RequireComponent(typeof(NVRHand))]
public class InventoryController : MonoBehaviour
{
    public Transform knivesPos;
    public Transform injectionsPos;
    public Transform medicinePos;
    public Transform weaponsPos;
    public Transform bombsPos;
    public Transform othersPos;
    public NVRButtons PickUpButton = NVRButtons.Trigger;
    public NVRButtons ShowInventoryButton = NVRButtons.Touchpad;
    public GameObject InventoryObject;
    public GameObject items;

    public PickableItem knife;
    public PickableItem bomb;
    public PickableItem medicine;
    public PickableItem waepon;
    public PickableItem injection;
    public PickableItem other;

    private NVRHand connectedHand;
    private AudioSource inventorySound;

    [HideInInspector]
    public Inventory inventory;

    void Awake()
    {
        connectedHand = this.GetComponent<NVRHand>();
        inventorySound = GetComponent<AudioSource>();
    }

    //Recaftor the pickup logic should not be part of the inventory logic
    private void LateUpdate()
    {
        if (connectedHand.Inputs[PickUpButton].PressDown == true)
        {
            Debug.Log("Pickup");
            PickupClosest();
        }
        if (connectedHand.Inputs[ShowInventoryButton].IsPressed == true)
        {
            Debug.Log("Call/Hide inventory");
            if (!InventoryObject.active)
            {
                InventoryObject.SetActive(true);
                items.SetActive(true);
            }
        }
        else if(InventoryObject.active)
        {
            InventoryObject.SetActive(false);
            items.SetActive(false);
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
        //add to  physical inventory
        switch (item.objectType)
        {
            case InventoryObjectType.Knife :
                Debug.Log("Knife added to inventory");
                inventory.AddKnifes(item.amount);
                break;
            case InventoryObjectType.Injection:
                Debug.Log("Injection added to inventory");
                inventory.AddInjections(item.amount);
                break;
            case InventoryObjectType.Medicine:
                Debug.Log("Medicine added to inventory");
                inventory.AddMedicine(item.amount);
                break;
            case InventoryObjectType.Weapon:
                Debug.Log("Weapon added to inventory");
                inventory.AddWeapons(item.amount);
                break;
            case InventoryObjectType.Bomb:
                Debug.Log("Bomb added to inventory");
                inventory.AddBombs(item.amount);
                break;
            case InventoryObjectType.Other:
                Debug.Log("Other added to inventory");
                inventory.AddOthers(item.amount);
                break;
        }
        item.gameObject.SetActive(false);
    }

    public Inventory getInventory()
    {
        return inventory;
    }

    //TODO
    private void removeFromInventory()
    {
       
    }
}
