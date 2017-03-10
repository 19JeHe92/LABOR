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
            if(chars[currentIndex].text.Equals(""))
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

    public enum Characters
    {
        Q, W, E, R, T, Z, U, I, O, P, A, S, D, F, G, H, J, K, L, Y, X, C, V, B, N, M
    }
}
