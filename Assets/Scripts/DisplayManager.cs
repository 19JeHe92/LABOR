using UnityEngine;
using UnityEngine.UI;

public class DisplayManager : MonoBehaviour
{
    public Text[] chars;

    private int currentIndex = 0;

    public void ReceiveCharacter(Characters character)
    {
        chars[currentIndex].text = character.ToString();
        if (currentIndex < 8)
            currentIndex++;
    }

    public void deleteCharacter()
    {
        if (currentIndex > 0)
        {
            if (chars[currentIndex].text.Equals(""))
            {
                currentIndex--;
            }
            else
            {
                chars[currentIndex].text = "";
            }
        }
        else
        {
            chars[currentIndex].text = "";
        }
    }

    public void ClearDisplay()
    {
        foreach (Text txt in chars)
        {
            txt.text = "";
            currentIndex = 0;
        }
    }

    public enum Characters
    {
        Q, W, E, R, T, Z, U, I, O, P, A, S, D, F, G, H, J, K, L, Y, X, C, V, B, N, M
    }

    public void ReceiveNumber(int num)
    {
        chars[currentIndex].text = num.ToString();
        if (currentIndex < 8)
            currentIndex++;
    }

    public enum Numbers
    {
        One = 1, Two = 2, Three = 3, Four = 4, Five = 5, Six = 6, Seven = 7, Eight = 8, Nine = 9, Zero = 0
    }
}
