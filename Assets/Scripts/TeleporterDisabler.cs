using UnityEngine;

//Disables the teleporter is the player is attacked
public class TeleporterDisabler : MonoBehaviour {

    public bool isAttacked = false;

    private TeleportVive teleporter;

    void Awake()
    {
        teleporter = GetComponent<TeleportVive>();
    }

    void Update()
    {
        if (isAttacked && teleporter.enabled)
        {
            teleporter.enabled = false;
        }
        else if(!isAttacked && teleporter.enabled == false)
        {
            teleporter.enabled = true;
        }

    }

}
