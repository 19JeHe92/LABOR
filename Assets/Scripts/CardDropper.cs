using System.Collections;
using UnityEngine;

//Drops a card if the robot is killed
public class CardDropper : MonoBehaviour {

    public GameObject robot;
    public GameObject card;

    public AudioSource hintToGoInOtherDirection;
	
	// Update is called once per frame
	void Update () {
        if (robot == null && !card.active)
        {
            card.active = true;
        }
	}

    private IEnumerator WaitAndPlaySound()
    {
        yield return new WaitForSeconds(2);
        hintToGoInOtherDirection.Play();
    }
}
