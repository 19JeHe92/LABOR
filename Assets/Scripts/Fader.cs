using UnityEngine;

//Black GUITexture used to get a smooth transition between screens
public class Fader : MonoBehaviour {

    public enum EFadeEffect
    {
        Black = 0,
        Transparent = 1
    }

    public EFadeEffect m_Effect = EFadeEffect.Black;

    private bool m_IsActive = false;

    [HideInInspector]
    public bool fadeToBlack = false;
    [HideInInspector]
    public bool fadeToTransparent = false;

    public float fadeSpeed = 0.8f;

    private GUITexture m_GUITexture;

    void Start()
    {
        m_GUITexture = GetComponent<GUITexture>();
    }

    //Life it seems, will fade away...
    void FadeToBlack()
    {
        m_GUITexture.color = Color.Lerp(GetComponent<GUITexture>().color, Color.black, fadeSpeed * Time.deltaTime);
    }

    //After darkness comes the light
    void FadeToTransparent()
    {
        m_GUITexture.color = Color.Lerp(GetComponent<GUITexture>().color, Color.clear, fadeSpeed * Time.deltaTime);
    }

    //There must be a cleaner solution than this
    void Update ()
    {
        if (m_IsActive == false) return;

        switch (m_Effect)
        {
            case EFadeEffect.Black:
                FadeToBlack();
                break;
            case EFadeEffect.Transparent:
                FadeToTransparent();
                break;
        }
	}

    void StartFading(bool _Flag)
    {
        m_IsActive = _Flag;
    }
}
