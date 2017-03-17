using System.Collections;
using UnityEngine;
using NewtonVR;
using UnityEngine.SceneManagement;

//Checks if the correct tubes have been inserted to the generator
//If the generator is solved(disabled) an explosion is instantiated an the next scene is loaded 
public class GeneratorColorsConroller : MonoBehaviour
{
    public float secondsBeforeLoadNextScene = 3;

    public NVRAttachJoint attachJoint1;
    public NVRAttachJoint attachJoint2;
    public NVRAttachJoint attachJoint3;
    public NVRAttachJoint attachJoint4;

    public GameObject explosion;
    public Transform explosionPosition;

    private bool exploded = false;

    void Update()
    {
        if (attachJoint1.AttachedItem && attachJoint2.AttachedItem && attachJoint1.AttachedItem && attachJoint1.AttachedItem)
        {
            //Debug.Log("Somehting attached to all points");
            if (!exploded && attachJoint1.AttachedItem.gameObject.tag == "CorrectTube1" && attachJoint2.AttachedItem.gameObject.tag == "CorrectTube2" && attachJoint3.AttachedItem.gameObject.tag == "CorrectTube3" && attachJoint4.AttachedItem.gameObject.tag == "CorrectTube4")
            {
              //  Debug.Log("Correct tubes attached");
                exploded = true;
                Instantiate(explosion, explosionPosition);
                StartCoroutine(LoadSceneAfterSeconds());
            }
        }
    }

    private IEnumerator LoadSceneAfterSeconds()
    {
        yield return new WaitForSeconds(secondsBeforeLoadNextScene);
      //  SceneManager.LoadScene("ChP12-Boss");
    }
}
