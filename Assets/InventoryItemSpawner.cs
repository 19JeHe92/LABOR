using UnityEngine;
using NewtonVR;

public class InventoryItemSpawner : MonoBehaviour {

    public GameObject prefabToSpawn;
    public InventoryObjectType typeToRemove;

    private void OnTriggerEnter (Collider other)
    {
        Debug.Log("Hand colliding with inventory object");
        NVRHand collidingHand = other.GetComponent<NVRHand>();
        if (collidingHand != null)
        {
            if (collidingHand.Inputs[NVRButtons.Grip].PressDown)
            {
                //Spawn an object and make the hand interact with it
                GameObject spawnedObject = (GameObject)Instantiate(prefabToSpawn, transform.position, transform.rotation);
                collidingHand.BeginInteraction(spawnedObject.GetComponent<NVRInteractableItem>());
            }
        }
    }
}
