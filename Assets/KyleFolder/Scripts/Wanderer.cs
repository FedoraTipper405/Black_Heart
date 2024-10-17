using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wanderer : Enemy
{
    private Transform _currentPoint;
    [SerializeField]
    public GameObject _PointA;
    [SerializeField]
    public GameObject _PointB;
    void Start()
    {
        _currentPoint = _PointB.transform;
    }
    protected override void Awake()
    {
        base.Awake();
    }
    protected override void Update()
    {
        base.Update();

        Vector2 point = _currentPoint.position - transform.position;
        if (_currentPoint == _PointB.transform)
        {
            rb.velocity = new Vector2(_speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-_speed, 0);
        }
        if (Vector2.Distance(transform.position, _currentPoint.position) < 0.5f && _currentPoint == _PointB.transform)
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
            _currentPoint = _PointA.transform;
        }
        if (Vector2.Distance(transform.position, _currentPoint.position) < 0.5f && _currentPoint == _PointA.transform)
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
            _currentPoint = _PointB.transform;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<IHealth>() != null)
        {
            collision.gameObject.GetComponent<IHealth>().TakeDamage(1);
        }
    }
}
