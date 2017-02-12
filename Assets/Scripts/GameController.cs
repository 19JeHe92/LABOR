using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GUITexture blackTexture;

    private void Awake()
    {
        
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        SceneManager.LoadScene("StartScene");
    }
}
