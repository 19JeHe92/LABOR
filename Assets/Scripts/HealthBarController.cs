﻿using UnityEngine;
using NewtonVR;
using UnityEngine.SceneManagement;
using System.Collections;

//Handles the health of the player and keeps the scaling of the green part ot the healt bar consistent to the players health
public class HealthBarController : MonoBehaviour
{
    public float SecondsBeforeReturn = 3f;
    public GameObject greenPart;
    public AudioSource dieingSound;
    public AudioSource ouchSound;
    public AudioSource deadSound;
    public int initialHealth;

    private Vector3 initialScale;
    private Vector3 currentScale;
    private Vector3 prevScale;

    private int currentHealth = 100;
    public NVRHand Hand;

    void Awake()
    {
        initialScale = greenPart.transform.localScale;
        currentScale = initialScale;
        prevScale = initialScale;
    }

    void Update()
    {
        transform.rotation = Hand.transform.rotation;
        transform.Rotate(90, 0, 0);
        transform.position = Hand.transform.position + (Hand.transform.up * 0.01f) - (Hand.transform.forward * 0.03f);
    }

    public void IncreaseHealth(int amount)
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

    public void DecreaseHealth(int amount)
    {
        ouchSound.Play();
        if (amount > 0)
        {
            int newHealth = currentHealth - amount;
            if (newHealth > 0)
            {
                if (newHealth < 30 && newHealth > 0 && currentHealth >= 30)
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
                positionSynch = -(prevScale.y - greenPart.transform.localScale.y) / 2;
            else
                positionSynch = (greenPart.transform.localScale.y - prevScale.y) / 2;
            greenPart.transform.localPosition += new Vector3(0, positionSynch, 0);
            prevScale = greenPart.transform.localScale;
            Debug.Log("Healthbar is now at " + health);
        }
    }

    private void Die()
    {
        deadSound.Play();
        StartCoroutine(WaitAndReturn());
    }

    private IEnumerator WaitAndReturn()
    {
        yield return new WaitForSeconds(SecondsBeforeReturn);
        SceneManager.LoadScene("StartScene");
    }


}
