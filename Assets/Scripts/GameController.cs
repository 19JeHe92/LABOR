using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GUITexture blackTexture;

    public void GameOver()
    {
        Debug.Log("Game Over");
        SceneManager.LoadScene("StartScene");
    }
}
