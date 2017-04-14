using UnityEngine;

public class LevelLoader : MonoBehaviour {

    public string levelName;

    public void Load()
    {
        SteamVR_LoadLevel.Begin(levelName);
    }
}
