using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour, IHealth
{
    [SerializeField]
    private int _health;
    [SerializeField]
    private int _maxHealth;
    [SerializeField]
    private Sprite _fullHeartSprite;
    [SerializeField]
    private Sprite _emptyHeartSprite;
    [SerializeField]
    private Image[] _hearts;
    void Start()
    {
        _health = _maxHealth;
    }

    void Update()
    {
        for (int i = 0; i < _hearts.Length; i++)
        {
            if (i < _health)
            {
                _hearts[i].sprite = _fullHeartSprite;
            }

            else
            {
                _hearts[i].sprite = _emptyHeartSprite;
            }

            if (i < _maxHealth)
            {
                _hearts[i].enabled = true;
            }
            else
            {
                _hearts[i].enabled = false;
            }
        }
    }

    public void TakeDamage()
    {
        _health--;
        if (_health <= 0)
        {
            Debug.Log("Death");
        }
    }
}
