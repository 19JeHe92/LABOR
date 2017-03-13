using UnityEngine;
using NewtonVR.Example;

public class WeaponFound : MonoBehaviour {

    public RoboFloorLoader roboFloorLoader;

    private NVRExampleGun gun;

    private void Awake()
    {
        gun = GetComponent<NVRExampleGun>();
    }

    void Update () {
        if (gun.IsAttached && !roboFloorLoader.isWeaponFound)
            roboFloorLoader.isWeaponFound = true;
	}
}
