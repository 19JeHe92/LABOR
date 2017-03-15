using UnityEngine;
using UnityEngine.SceneManagement;

public class GlasBreaker : MonoBehaviour {

    public GameObject brokenGlasPrefab;


	private void OnCollisionEnter(Collider other)
    {
        if (other.gameObject.GetComponent<ShellExplosion>())
        {
            Debug.Log("Glas hit by shell");
            GameObject brokenGlas = Instantiate(brokenGlasPrefab, transform);
            brokenGlas.transform.parent = null;
            Destroy(gameObject);
        }
    }
}
