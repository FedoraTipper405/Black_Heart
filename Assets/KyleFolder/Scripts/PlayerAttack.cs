using Code.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float timeBetweenAttack;
    public float timeSinceAttack;
    public Transform attackTransform;
    public Vector2 attackArea;
    public LayerMask AttackableLayer;
    public float _damage;

    private Animator _animator;

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    void Start()
    {

    }


    void Update()
    {
        timeSinceAttack += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.R))
        {
            _animator.Play(PlayerAnimationConstants.ATTACK);
            if (timeSinceAttack >= timeBetweenAttack)
            {
                timeSinceAttack = 0;
                Hit();
            }
        }
    }

    private void Hit()
    {
        Collider2D[] objectsHit = Physics2D.OverlapBoxAll(attackTransform.position, attackArea, 0, AttackableLayer);
        
        for (int i = 0; i < objectsHit.Length; i++)
        {
            if (objectsHit[i].GetComponent<Enemy>() != null)
            {
                objectsHit[i].GetComponent<Enemy>().EnemyHit(_damage);
                Debug.Log("Ouch");
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(attackTransform.position, attackArea);
    }
}
