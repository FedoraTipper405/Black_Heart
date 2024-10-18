using Code.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
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
    [SerializeField]
    private UnityEvent _death;
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

    public void TakeDamage(int damage)
    {
        _health = _health - damage;
        StartCoroutine(StopTakingDamage());
        if (_health <= 0)
        {
            Debug.Log("Death");
            PlayerAttack attack = GetComponent<PlayerAttack>();
            attack._disableAttack = true;
            Dash dash = GetComponent<Dash>();
            dash._disableDash = true;
            PlayerController controller = GetComponent<PlayerController>();
            controller.enabled = false;
            _death.Invoke();
        }
    }
    IEnumerator StopTakingDamage()
    {
        Physics2D.IgnoreLayerCollision(6, 7, true);
        yield return new WaitForSeconds(3f);
        Physics2D.IgnoreLayerCollision(6, 7, false);
    }
}
