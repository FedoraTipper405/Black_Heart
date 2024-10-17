using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    protected float _enemyHealth;
    [SerializeField]
    protected float _speed;
    protected Rigidbody2D rb;
    [SerializeField]
    private GameObject Blood;
    void Start()
    {

    }

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void Update()
    {
        if (_enemyHealth <= 0)
        {
            Destroy(gameObject);
            Instantiate(Blood, transform.position, Quaternion.identity);
            AudioManager.PlaySound(SoundClip.BloodSplat);
        }
    }

    public virtual void EnemyHit(float _damageDone)
    {
        _enemyHealth -= _damageDone;
    }
}
