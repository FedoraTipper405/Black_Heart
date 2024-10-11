using Code.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private float _timeBetweenAttack;
    [SerializeField]
    private float _timeSinceAttack;
    [SerializeField]
    private Transform _attackTransform;
    [SerializeField]
    private Vector2 _attackArea;
    [SerializeField]
    private LayerMask _attackableLayer;
    [SerializeField]
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
        _timeSinceAttack += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.R))
        {
            _animator.Play(PlayerAnimationConstants.ATTACK);
            if (_timeSinceAttack >= _timeBetweenAttack)
            {
                _timeSinceAttack = 0;
                Hit();
            }
        }
    }

    private void Hit()
    {
        Collider2D[] objectsHit = Physics2D.OverlapBoxAll(_attackTransform.position, _attackArea, 0, _attackableLayer);
        
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
        Gizmos.DrawWireCube(_attackTransform.position, _attackArea);
    }
}
