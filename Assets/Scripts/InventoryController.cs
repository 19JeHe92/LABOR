using UnityEngine;
using NewtonVR;
using UnityEngine.UI;

//We are not using RequireComponent because:
//RequireComponent impies the error "Can't remove NVRHand Script because ... Script depends on it", which causes the game to crash
//[RequireComponent(typeof(NVRHand))]
public class InventoryController : MonoBehaviour
{
    public int initialKnivesAmount = 3;
    public int initialInjectionsAmount = 3;
    public int initialBombsAmount = 3;
    public int initialMedicineAmount = 3;
    public int initialWeaponsAmount = 3;
    public int initialCardsAmount = 3;


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
    private int injectionsAmount = 0;
    private int bombsAmount = 0;
    private int weaponsAmount = 0;
    private int medicineAmount = 0;
    private int cardsAmount = 0;

    void Awake()
    {
        InitInventory();
        connectedHand = this.GetComponent<NVRHand>();
        inventorySound = GetComponent<AudioSource>();
    }

    private void InitInventory()
    {
        knivesAmount = initialKnivesAmount;
        injectionsAmount = initialInjectionsAmount;
        bombsAmount = initialBombsAmount;
        weaponsAmount = initialWeaponsAmount;
        medicineAmount = initialMedicineAmount;
        cardsAmount = initialCardsAmount;
        UpdateInventoryGUI();
    }

    private void UpdateInventoryGUI()
    {
        knivesAmountText.text = knivesAmount.ToString();
        injectionsAmountText.text = injectionsAmount.ToString();
        medicineAmountText.text = medicineAmount.ToString();
        weaponsAmountText.text = weaponsAmount.ToString();
        bombsAmountText.text = bombsAmount.ToString();
        cardsAmountText.text = cardsAmount.ToString();
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
                float xRot = InventoryObject.transform.localRotation.x;
                float yRot = connectedHand.transform.localRotation.y;
                float zRot = connectedHand.transform.rotation.z;
                InventoryObject.transform.rotation = new Quaternion(xRot, yRot, zRot, 1);
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
                UpdateInventoryGUI();
                break;
            case InventoryObjectType.Injection:
                Debug.Log("Injection added to inventory");
                injectionsAmount++;
                UpdateInventoryGUI();
                break;
            case InventoryObjectType.Medicine:
                Debug.Log("Medicine added to inventory");
                medicineAmount++;
                UpdateInventoryGUI();
                break;
            case InventoryObjectType.Weapon:
                Debug.Log("Weapon added to inventory");
                weaponsAmount++;
                UpdateInventoryGUI();
                break;
            case InventoryObjectType.Bomb:
                Debug.Log("Bomb added to inventory");
                bombsAmount++;
                UpdateInventoryGUI();
                break;
            case InventoryObjectType.Card:
                Debug.Log("Card added to inventory");
                cardsAmount++;
                UpdateInventoryGUI();
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
                    UpdateInventoryGUI();
                    success = true;
                }
                break;
            case InventoryObjectType.Injection:
                if (injectionsAmount > 0)
                {
                    Debug.Log("Injection removed from inventory");
                    injectionsAmount--;
                    UpdateInventoryGUI();
                    success = true;
                }
                break;
            case InventoryObjectType.Medicine:
                if (medicineAmount > 0)
                {
                    Debug.Log("Medicine removed from inventory");
                    medicineAmount--;
                    UpdateInventoryGUI();
                    success = true;
                }
                break;
            case InventoryObjectType.Weapon:
                if(weaponsAmount > 0)
                {
                    Debug.Log("Weapon removed from inventory");
                    weaponsAmount--;
                    UpdateInventoryGUI();
                    success = true;
                }
                break;
            case InventoryObjectType.Bomb:
                if(bombsAmount > 0)
                {
                    Debug.Log("Bomb removed from inventory");
                    bombsAmount--;
                    UpdateInventoryGUI();
                    success = true;
                }
                break;
            case InventoryObjectType.Card:
                if(cardsAmount > 0)
                {
                    Debug.Log("Card removed from inventory");
                    cardsAmount--;
                    UpdateInventoryGUI();
                    success = true;
                }
                break;
        }
        return success;
    }
}
