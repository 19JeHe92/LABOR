using UnityEngine;
using System.Collections;

public class PiepController : MonoBehaviour {

    public float secondsBeforeStart = 10;
    public GameObject Knob;
    public Light redLed;
    public int secondsbetweenBlinks = 1;

    private AudioSource piep;

    private IEnumerator StartSound()
    {
        yield return new WaitForSeconds(secondsBeforeStart);
        piep.Play();
        piep.loop = true;
    }

    void Awake()
    {
        piep = GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Start () {
        StartCoroutine("StartSound");
        StartCoroutine("blinking");
    }
	
	void Update () {
        if (((int)Knob.transform.eulerAngles.z) <= 80)
        {
            piep.Stop();
            StopCoroutine("blinking");
            redLed.enabled = false;
        }
    }

    private IEnumerator blinking()
    {
        yield return new WaitForSeconds(secondsBeforeStart);
        while (true)
        {
            yield return new WaitForSeconds(secondsbetweenBlinks);
            redLed.enabled = !redLed.enabled;
        }
    }
}
