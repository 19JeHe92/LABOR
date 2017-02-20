using UnityEngine;

public class StartNewGame : MonoBehaviour {

    public StartController mainController;

	public void StartGame()
    {
        mainController.LoadScene(Checkpoints.FirstRoom);
    }
}
