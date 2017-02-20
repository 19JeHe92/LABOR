using UnityEngine;
using NewtonVR;

public class HealthBarController : MonoBehaviour {

    public GameObject greenPart;
    public GameObject redPart;
    public NVRHand attachedHand;

    public int currentHealth = 100;
    public bool isVisible = false;
    public NVRButtons showHealthButton = NVRButtons.ApplicationMenu;

    private Vector3 initialScale;

    public void Awake()
    {
        initialScale = greenPart.transform.localScale;
    }

    public void increaseHealth(int amount)
    {
        if (amount > 0)
        {
            if (amount + currentHealth < 100)
            {
                currentHealth += amount;
                ScaleGreenPart(currentHealth);
            }
            else
            {
                currentHealth = 100;
                ScaleGreenPart(currentHealth);
            }
        }
    }

    public void decreaseHealth(int amount)
    {
        if (amount > 0)
        {
            if (amount - currentHealth > 0)
            {
                currentHealth -= amount;
                ScaleGreenPart(currentHealth);
            }
            else
            {
                currentHealth = 0;
                ScaleGreenPart(currentHealth);
            }
        }
    }

    private void ScaleGreenPart(int health)
    {
        if(health < 101 && health >= 0)
        {
            greenPart.transform.localScale = new Vector3(greenPart.transform.localScale.x, health * initialScale.y / 100, greenPart.transform.localScale.z );
            greenPart.transform.localPosition += new Vector3(0, -(initialScale.y - health * initialScale.y / 100)/2, 0);
            Debug.Log("Healthbar is now at " + health);
        }
    }


}
