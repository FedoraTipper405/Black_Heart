using Code.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flyer : Enemy
{

    private GameObject _player;
    private float _distance;
    public float _radius;
    private Animator _animator;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _animator = GetComponent<Animator>();
    }

    protected override void Awake()
    {
        base.Awake();
    }
    
    protected override void Update()
    {
        base.Update();
        
        _distance = Vector2.Distance(transform.position, _player.transform.position);
        if(_distance < _radius)
        {
            Vector2 direction = _player.transform.forward - transform.position;

            transform.position = Vector2.MoveTowards(this.transform.position, _player.transform.position, _speed * Time.deltaTime);
            this.GetComponent<SpriteRenderer>().flipX = _player.transform.position.x <= 1f;
            _animator.Play(FlyerAnimationConstants.CHASE);
        }

    }
    private void flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<IHealth>() != null)
        {
            collision.gameObject.GetComponent<IHealth>().TakeDamage(1);
        }
    }
}
