using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadPrisoner : MonoBehaviour
{
    private Transform _currentPoint;
    private GameObject _PointA;
    private GameObject _PointB;
    private Rigidbody2D rb;
    [SerializeField]
    private float _speed;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        _PointA = GameObject.FindGameObjectWithTag("PointA");
        _PointB = GameObject.FindGameObjectWithTag("PointB");
        _currentPoint = _PointB.transform;
    }

    void FixedUpdate()
    {
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
}
