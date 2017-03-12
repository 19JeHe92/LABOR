using UnityEngine;
using NewtonVR;
using UnityEngine.SceneManagement;
using System.Collections;

public class HealthBarController : MonoBehaviour
{
    public float SecondsBeforeReturn = 3f;
    public GameObject greenPart;
    public AudioSource dieingSound;
    public int initialHealth;

    private Vector3 initialScale;
    private Vector3 currentScale;
    private Vector3 prevScale;

    public bool isVisible = false;
    public NVRButtons showHealthButton = NVRButtons.ApplicationMenu;
    public GameObject HealthBar;

    private int currentHealth = 100;
    private NVRHand Hand;

    private void Awake()
    {
        Hand = this.GetComponent<NVRHand>();
        initialScale = greenPart.transform.localScale;
        currentScale = initialScale;
        prevScale = initialScale;
    }

    private void LateUpdate()
    {
        if (Hand.Inputs[showHealthButton].IsPressed == true)
        {
            if (!HealthBar.active)
            {
                //Debug.Log("Show health!");
                HealthBar.SetActive(true);
            }
        }
        else if (HealthBar.active)
        {
            // Debug.Log("Hide Health!");
            HealthBar.SetActive(false);
        }

    }

    public void increaseHealth(int amount)
    {
        if (amount > 0)
        {
            if (amount + currentHealth < 100)
            {
                currentHealth += amount;
                ScaleGreenPart(currentHealth, false);
            }
            else
            {
                currentHealth = 100;
                ScaleGreenPart(currentHealth, false);
            }
        }
    }

    public void decreaseHealth(int amount)
    {
        if (amount > 0)
        {
            if (currentHealth - amount > 0)
            {
                if (currentHealth - amount < 30 && currentHealth >= 30)
                {
                    dieingSound.Play();
                    Debug.Log("Player hint: You're dieing");
                }
                currentHealth -= amount;
                ScaleGreenPart(currentHealth, true);
            }
            else
            {
                Die();
            }
        }
    }

    private void ScaleGreenPart(int health, bool decreasing)
    {
        if (health < 101 && health >= 0)
        {
            greenPart.transform.localScale = new Vector3(greenPart.transform.localScale.x, health * initialScale.y / 100, greenPart.transform.localScale.z);
            float positionSynch;
            if (decreasing)
                positionSynch = -(prevScale.y - greenPart.transform.localScale.y) /2;
            else
                positionSynch = (greenPart.transform.localScale.y - prevScale.y) / 2;
            greenPart.transform.localPosition += new Vector3(0, positionSynch, 0);
            prevScale = greenPart.transform.localScale;
            Debug.Log("Healthbar is now at " + health);
        }
    }

    private void Die()
    {
        StartCoroutine(WaitAndReturn());
    }

    private IEnumerator WaitAndReturn()
    {
        yield return new WaitForSeconds(SecondsBeforeReturn);
        SceneManager.LoadScene("StartScene");
    }


}
