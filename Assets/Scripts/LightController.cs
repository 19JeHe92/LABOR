using System.Collections;
using UnityEngine;

public class LightController : MonoBehaviour {

    public GameObject Light1;
    public GameObject Light2;
    public GameObject Light3;
    public GameObject Light4;

    public Color BlueButtonColor;
    public Color RedButtonColor;
    public Color GreenButtonColor;
    public Color VioletButtonColor;
    public Color BrownButtonColor;
    public Color OrangeButtonColor;

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
        Light1.GetComponent<Renderer>().material.color = BlueButtonColor ;
        yield return new WaitForSeconds(1);
        Light1.GetComponent<Renderer>().material.color = Color.white;
        yield return new WaitForSeconds(1);
        Light2.GetComponent<Renderer>().material.color = GreenButtonColor ;
        yield return new WaitForSeconds(1);
        Light2.GetComponent<Renderer>().material.color = Color.white;
        yield return new WaitForSeconds(1);
        Light3.GetComponent<Renderer>().material.color = RedButtonColor ;
        yield return new WaitForSeconds(1);
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
        Light2.GetComponent<Renderer>().material.color = OrangeButtonColor;//orange
        yield return new WaitForSeconds(1);
        Light2.GetComponent<Renderer>().material.color = Color.white;
        yield return new WaitForSeconds(1);

     
        Light4.GetComponent<Renderer>().material.color = VioletButtonColor;//violet
        yield return new WaitForSeconds(1);
        Light4.GetComponent<Renderer>().material.color = Color.white;
        yield return new WaitForSeconds(1);

        Light2.GetComponent<Renderer>().material.color = BlueButtonColor;//blue
        yield return new WaitForSeconds(1);
        Light2.GetComponent<Renderer>().material.color = Color.white;
        yield return new WaitForSeconds(1);

        Light3.GetComponent<Renderer>().material.color = BrownButtonColor;//brown
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
        Light1.GetComponent<Renderer>().material.color = VioletButtonColor;//violet
        yield return new WaitForSeconds(1);
        Light1.GetComponent<Renderer>().material.color = Color.white;
        yield return new WaitForSeconds(1);


        Light2.GetComponent<Renderer>().material.color = OrangeButtonColor;//orange
        yield return new WaitForSeconds(1);
        Light2.GetComponent<Renderer>().material.color = Color.white;
        yield return new WaitForSeconds(1);

        Light3.GetComponent<Renderer>().material.color = GreenButtonColor;//green
        yield return new WaitForSeconds(1);
        Light3.GetComponent<Renderer>().material.color = Color.white;
        yield return new WaitForSeconds(1);

        Light4.GetComponent<Renderer>().material.color = RedButtonColor;//red
        yield return new WaitForSeconds(1);
        Light4.GetComponent<Renderer>().material.color = Color.white;
        yield return new WaitForSeconds(1);

        Light1.GetComponent<Renderer>().material.color = BlueButtonColor;//blue
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
        Light1.GetComponent<Renderer>().material.color = RedButtonColor;//red
        yield return new WaitForSeconds(1);

        Light2.GetComponent<Renderer>().material.color = GreenButtonColor;//green
        yield return new WaitForSeconds(1);

        Light3.GetComponent<Renderer>().material.color = BlueButtonColor;//blue
        yield return new WaitForSeconds(1);

        Light4.GetComponent<Renderer>().material.color = VioletButtonColor;//violet
        yield return new WaitForSeconds(1);
    }
}
