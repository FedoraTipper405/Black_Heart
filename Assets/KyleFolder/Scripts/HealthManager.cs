using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour, IHealth
{
    public int health;
    public int maxHealth;

    public Sprite fullHeart;
    public Sprite emptyHeartSprite;
    public Image[] hearts;
    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }

            else
            {
                hearts[i].sprite = emptyHeartSprite;
            }

            if (i < maxHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    public void TakeDamage()
    {
        health--;
        if (health <= 0)
        {
            Debug.Log("Death");
        }
    }
}
