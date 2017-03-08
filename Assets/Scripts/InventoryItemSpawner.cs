﻿using UnityEngine;
using NewtonVR;
using NewtonVR.Example;
using System;

public class InventoryItemSpawner : MonoBehaviour
{

    public GameObject prefabToSpawn;
    public InventoryObjectType typeToRemove;
    public NVRHand leftHand;
    public NVRHand rightHand;
    public Vector3 offsetToActivateSpawner = new Vector3(0.1f, 0.1f, 0.1f);
    public InventoryController inevtoryController;

    void Update()
    {
        Vector3 offsetToLeftHand = Vector3Abs(leftHand.transform.position - transform.position);
        Vector3 offsetToRightHand = Vector3Abs(rightHand.transform.position - transform.position);
        if ((offsetToActivateSpawner.x > offsetToLeftHand.x && offsetToActivateSpawner.y > offsetToLeftHand.y && offsetToActivateSpawner.z > offsetToLeftHand.z))
        {
            Debug.Log("Left Hand colliding with inventory object");
            SpawnObjectInHand(leftHand);
        }
        else if (offsetToActivateSpawner.x > offsetToRightHand.x && offsetToActivateSpawner.y > offsetToRightHand.y && offsetToActivateSpawner.z > offsetToRightHand.z)
        {
            Debug.Log("Right Hand colliding with inventory object");
            SpawnObjectInHand(rightHand);
        }
    }

    private void SpawnObjectInHand(NVRHand hand)
    {
        if (hand.Inputs[NVRButtons.Grip].PressDown)
        {
            if (inevtoryController.RemovefromInventory(typeToRemove))
            {
                Debug.Log("Successfully removed item");
                //Spawn an object and make the hand interact with it
                GameObject spawnedObject = (GameObject)Instantiate(prefabToSpawn, transform.position, transform.rotation);
                NVRInteractableItem item = spawnedObject.GetComponent<NVRInteractableItem>();
                if (item != null)
                    hand.BeginInteraction(item);
                else
                    hand.BeginInteraction(spawnedObject.GetComponent<NVRExampleGun>());
            }
        }
    }

    private Vector3 Vector3Abs(Vector3 vec3)
    {
        Vector3 result = new Vector3(Math.Abs(vec3.x), Math.Abs(vec3.y), Math.Abs(vec3.z));
        return result;
    }
}
