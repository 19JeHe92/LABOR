using System.Collections;
using UnityEngine;

//Controls the lights of the simon game
public class LightController : MonoBehaviour {

    public GameObject Light1;
    public GameObject Light2;
    public GameObject Light3;
    public GameObject Light4;

    public Color Button1Color;
    public Color Button2Color;
    public Color Button3Color;
    public Color Button4Color;
    public Color Button5Color;
    public Color Button6Color;

    public AudioSource lightSound;

    public float glowingSpeed = 0.2f;

    public IEnumerator StartFirstRound()
    {
        Color lerpedColor;
        for (int j = 0; j < 3; j++)
        {
            for (float i = 0; i <= 1; i += 0.1f)
            {
                lerpedColor = Color.Lerp(Color.white, Color.green, i);
                Light1.GetComponent<Renderer>().material.color = lerpedColor;
                Light2.GetComponent<Renderer>().material.color = lerpedColor;
                Light3.GetComponent<Renderer>().material.color = lerpedColor;
                Light4.GetComponent<Renderer>().material.color = lerpedColor;

                yield return new WaitForSeconds(0.04f);
            }
            for (float i = 0; i <= 1; i += 0.1f)
            {
                lerpedColor = Color.Lerp(Color.green, Color.white, i);
                Light1.GetComponent<Renderer>().material.color = lerpedColor;
                Light2.GetComponent<Renderer>().material.color = lerpedColor;
                Light3.GetComponent<Renderer>().material.color = lerpedColor;
                Light4.GetComponent<Renderer>().material.color = lerpedColor;

                yield return new WaitForSeconds(0.04f);
            }
        }
        StartCoroutine("ShowFirstRoundColors");
    }

    private IEnumerator ShowFirstRoundColors()
    {
        yield return new WaitForSeconds(1);
        lightSound.Play();
        Light1.GetComponent<Renderer>().material.color = Button1Color ;

        yield return new WaitForSeconds(1);
        Light1.GetComponent<Renderer>().material.color = Color.white;

        yield return new WaitForSeconds(1);
        lightSound.Play();
        Light2.GetComponent<Renderer>().material.color = Button3Color ;

        yield return new WaitForSeconds(1);
        Light2.GetComponent<Renderer>().material.color = Color.white;

        yield return new WaitForSeconds(1);
        lightSound.Play();
        Light3.GetComponent<Renderer>().material.color = Button2Color ;

        yield return new WaitForSeconds(1);
        lightSound.Play();
        Light3.GetComponent<Renderer>().material.color = Color.white;
        yield return new WaitForSeconds(1);
    }

    public IEnumerator BlinkRed()
    {
        Color lerpedColor;
        for (int j = 0; j < 3; j++)
        {
            for (float i = 0; i <= 1; i += 0.1f)
            {
                lerpedColor = Color.Lerp(Color.white, Color.red, i);
                Light1.GetComponent<Renderer>().material.color = lerpedColor;
                Light2.GetComponent<Renderer>().material.color = lerpedColor;
                Light3.GetComponent<Renderer>().material.color = lerpedColor;
                Light4.GetComponent<Renderer>().material.color = lerpedColor;

                yield return new WaitForSeconds(0.04f);
            }
            for (float i = 0; i <= 1; i += 0.1f)
            {
                lerpedColor = Color.Lerp(Color.red, Color.white, i);
                Light1.GetComponent<Renderer>().material.color = lerpedColor;
                Light2.GetComponent<Renderer>().material.color = lerpedColor;
                Light3.GetComponent<Renderer>().material.color = lerpedColor;
                Light4.GetComponent<Renderer>().material.color = lerpedColor;

                yield return new WaitForSeconds(0.04f);
            }
        }
    }

    public IEnumerator BlinkGreen()
    {
        Color lerpedColor;
        for (int j = 0; j < 3; j++)
        {
            for (float i = 0; i <= 1; i += 0.1f)
            {
                lerpedColor = Color.Lerp(Color.white, Color.green, i);
                Light1.GetComponent<Renderer>().material.color = lerpedColor;
                Light2.GetComponent<Renderer>().material.color = lerpedColor;
                Light3.GetComponent<Renderer>().material.color = lerpedColor;
                Light4.GetComponent<Renderer>().material.color = lerpedColor;

                yield return new WaitForSeconds(0.04f);
            }
            for (float i = 0; i <= 1; i += 0.1f)
            {
                lerpedColor = Color.Lerp(Color.green, Color.white, i);
                Light1.GetComponent<Renderer>().material.color = lerpedColor;
                Light2.GetComponent<Renderer>().material.color = lerpedColor;
                Light3.GetComponent<Renderer>().material.color = lerpedColor;
                Light4.GetComponent<Renderer>().material.color = lerpedColor;

                yield return new WaitForSeconds(0.04f);
            }
        }
    }

    public IEnumerator ShowSecondRoundColors()
    {
        Color lerpedColor;
        for (int j = 0; j < 3; j++)
        {
            for (float i = 0; i <= 1; i += 0.1f)
            {
                lerpedColor = Color.Lerp(Color.white, Color.green, i);
                Light1.GetComponent<Renderer>().material.color = lerpedColor;
                Light2.GetComponent<Renderer>().material.color = lerpedColor;
                Light3.GetComponent<Renderer>().material.color = lerpedColor;
                Light4.GetComponent<Renderer>().material.color = lerpedColor;

                yield return new WaitForSeconds(0.04f);
            }
            for (float i = 0; i <= 1; i += 0.1f)
            {
                lerpedColor = Color.Lerp(Color.green, Color.white, i);
                Light1.GetComponent<Renderer>().material.color = lerpedColor;
                Light2.GetComponent<Renderer>().material.color = lerpedColor;
                Light3.GetComponent<Renderer>().material.color = lerpedColor;
                Light4.GetComponent<Renderer>().material.color = lerpedColor;

                yield return new WaitForSeconds(0.04f);
            }
        }

        yield return new WaitForSeconds(1);
        lightSound.Play();
        Light2.GetComponent<Renderer>().material.color = Button6Color;//orange

        yield return new WaitForSeconds(1);
        Light2.GetComponent<Renderer>().material.color = Color.white;

        yield return new WaitForSeconds(1);
        lightSound.Play();
        Light4.GetComponent<Renderer>().material.color = Button4Color;//violet

        yield return new WaitForSeconds(1);
        Light4.GetComponent<Renderer>().material.color = Color.white;

        yield return new WaitForSeconds(1);
        lightSound.Play();
        Light2.GetComponent<Renderer>().material.color = Button1Color;//blue

        yield return new WaitForSeconds(1);
        Light2.GetComponent<Renderer>().material.color = Color.white;

        yield return new WaitForSeconds(1);
        lightSound.Play();
        Light3.GetComponent<Renderer>().material.color = Button5Color;//brown
        yield return new WaitForSeconds(1);
        Light3.GetComponent<Renderer>().material.color = Color.white;
        yield return new WaitForSeconds(1);
    }

    public IEnumerator ShowThirdRoundColors()
    {
        Color lerpedColor;
        for (int j = 0; j < 3; j++)
        {
            for (float i = 0; i <= 1; i += 0.1f)
            {
                lerpedColor = Color.Lerp(Color.white, Color.green, i);
                Light1.GetComponent<Renderer>().material.color = lerpedColor;
                Light2.GetComponent<Renderer>().material.color = lerpedColor;
                Light3.GetComponent<Renderer>().material.color = lerpedColor;
                Light4.GetComponent<Renderer>().material.color = lerpedColor;

                yield return new WaitForSeconds(0.04f);
            }
            for (float i = 0; i <= 1; i += 0.1f)
            {
                lerpedColor = Color.Lerp(Color.green, Color.white, i);
                Light1.GetComponent<Renderer>().material.color = lerpedColor;
                Light2.GetComponent<Renderer>().material.color = lerpedColor;
                Light3.GetComponent<Renderer>().material.color = lerpedColor;
                Light4.GetComponent<Renderer>().material.color = lerpedColor;

                yield return new WaitForSeconds(0.04f);
            }
        }

        yield return new WaitForSeconds(1);

        lightSound.Play();
        Light1.GetComponent<Renderer>().material.color = Button4Color;//violet
        yield return new WaitForSeconds(1);
        Light1.GetComponent<Renderer>().material.color = Color.white;
        yield return new WaitForSeconds(1);

        lightSound.Play();

        Light2.GetComponent<Renderer>().material.color = Button6Color;//orange
        yield return new WaitForSeconds(1);
        Light2.GetComponent<Renderer>().material.color = Color.white;
        yield return new WaitForSeconds(1);

        lightSound.Play();

        Light3.GetComponent<Renderer>().material.color = Button3Color;//green
        yield return new WaitForSeconds(1);
        Light3.GetComponent<Renderer>().material.color = Color.white;
        yield return new WaitForSeconds(1);

        lightSound.Play();

        Light4.GetComponent<Renderer>().material.color = Button2Color;//red
        yield return new WaitForSeconds(1);
        Light4.GetComponent<Renderer>().material.color = Color.white;
        yield return new WaitForSeconds(1);

        lightSound.Play();

        Light1.GetComponent<Renderer>().material.color = Button1Color;//blue
        yield return new WaitForSeconds(1);
        Light1.GetComponent<Renderer>().material.color = Color.white;
        yield return new WaitForSeconds(1);
    }

    public IEnumerator ShowCorrectCombination()
    {
        Color lerpedColor;
        for (int j = 0; j < 3; j++)
        {
            for (float i = 0; i <= 1; i += 0.1f)
            {
                lerpedColor = Color.Lerp(Color.white, Color.green, i);
                Light1.GetComponent<Renderer>().material.color = lerpedColor;
                Light2.GetComponent<Renderer>().material.color = lerpedColor;
                Light3.GetComponent<Renderer>().material.color = lerpedColor;
                Light4.GetComponent<Renderer>().material.color = lerpedColor;

                yield return new WaitForSeconds(0.04f);
            }
            for (float i = 0; i <= 1; i += 0.1f)
            {
                lerpedColor = Color.Lerp(Color.green, Color.white, i);
                Light1.GetComponent<Renderer>().material.color = lerpedColor;
                Light2.GetComponent<Renderer>().material.color = lerpedColor;
                Light3.GetComponent<Renderer>().material.color = lerpedColor;
                Light4.GetComponent<Renderer>().material.color = lerpedColor;

                yield return new WaitForSeconds(0.04f);
            }
        }

        //correct combination
        yield return new WaitForSeconds(1);
        Light1.GetComponent<Renderer>().material.color = Button2Color;
        yield return new WaitForSeconds(1);

        Light2.GetComponent<Renderer>().material.color = Button3Color;
        yield return new WaitForSeconds(1);

        Light3.GetComponent<Renderer>().material.color = Button1Color;
        yield return new WaitForSeconds(1);

        Light4.GetComponent<Renderer>().material.color = Button4Color;
        yield return new WaitForSeconds(1);
    }
}
