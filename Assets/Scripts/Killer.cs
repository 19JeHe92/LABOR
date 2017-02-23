using UnityEngine;

public class Killer : MonoBehaviour {

    public GameController controller;

	void OnTriggerEnter(Collider target)
    {
            Debug.Log("Trigger works");
        if (target.GetComponent<RobotContoller>() != null)
        {
            //player dead
            controller.ReturnToMainMenu();
        }
    }
}
