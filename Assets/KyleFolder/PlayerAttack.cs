using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float timeBetweenAttack;
    public float timeSinceAttack;
    public Transform attackTransform;
    public Vector2 attackArea;
    public LayerMask EnemyMask;

    void Start()
    {

    }


    void Update()
    {
        timeSinceAttack += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (timeSinceAttack >= timeBetweenAttack)
            {
                timeSinceAttack = 0;
                Hit();
            }
        }
    }

    private void Hit()
    {
        Collider2D[] enemyHit = Physics2D.OverlapBoxAll(attackTransform.position, attackArea, 0, EnemyMask);
        if (enemyHit.Length > 0)
        {
            Debug.Log("Hit");
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(attackTransform.position, attackArea);
    }
}
