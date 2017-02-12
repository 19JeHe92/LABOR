using System.Collections;
using NewtonVR;
using UnityEngine;

public class InventotyBoard : MonoBehaviour {

    public Transform[] obj1Pos;

    private int objectIndex;

    public void AddObject(NVRInteractableItem obj)
    {
        if (objectIndex < 5)
        {
            obj.transform.position = obj1Pos[objectIndex++].position;
            //obj.transform.parent = transform;
        }
    }
}
