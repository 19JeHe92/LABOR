using UnityEngine;

public class ScarePlayer : MonoBehaviour {

    public GameObject startSceneBoss;

    public void Scare()
    {
        GameObject boss = Instantiate(startSceneBoss);
    }
}
