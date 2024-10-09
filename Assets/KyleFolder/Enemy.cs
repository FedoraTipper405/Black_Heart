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
        }
    }

    public virtual void EnemyHit(float _damageDone)
    {
        _enemyHealth -= _damageDone;
    }
}
