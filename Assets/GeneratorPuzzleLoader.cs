using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeneratorPuzzleLoader : MonoBehaviour {

    public GameObject glas;
    public float secondsBeforeLoad = 3f;

    void Update()
    {
        if (!glas)
        {
            StartCoroutine(LoadSceneAfterSeconds());
        }
    }

    private IEnumerator LoadSceneAfterSeconds()
    {
        yield return new WaitForSeconds(secondsBeforeLoad);
        SceneManager.LoadScene("ChP9-RobotRoom-Control");
    }
}
