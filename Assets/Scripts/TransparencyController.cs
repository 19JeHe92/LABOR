using System.Collections;
using UnityEngine;

public class TransparencyController : MonoBehaviour {

    public float SecondsBeforeTransparent = 6.0f;
    public float SecondsAfterTransparent = 10.0f;

    IEnumerator StartAndShutdown()
    {
        yield return new WaitForSeconds(SecondsBeforeTransparent);
        for (float f = 1f; f >= 0; f -= 0.1f)
        {
            Color c = GetComponent<Renderer>().material.color;
            c.a = f;
            GetComponent<Renderer>().material.color = c;
            yield return new WaitForSeconds(0.1f);
        }
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(SecondsAfterTransparent);
        for (float f = 0f; f <= 2; f += 0.1f)
        {
            Color c = GetComponent<Renderer>().material.color;
            c.a = f;
            GetComponent<Renderer>().material.color = c;
            yield return new WaitForSeconds(0.1f);
        }
    }

    void Start()
    {
        StartCoroutine("StartAndShutdown");
    }

}
