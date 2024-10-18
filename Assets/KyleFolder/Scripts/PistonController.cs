using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistonController : MonoBehaviour
{
    [SerializeField]
    public float _uppwardSpeed;
    [SerializeField]    
    public float _downpwardSpeed;
    [SerializeField]
    private Transform _upTransform;
    [SerializeField] 
    private Transform _downTransform;
    bool _changeDirection;
    public bool _canMove;

    void Start()
    {
        _canMove = false;    
    }

    void Update()
    {
        if (_canMove)
        {
            if (transform.position.y >= _upTransform.position.y)
            {
                _changeDirection = true;
            }
            if (transform.position.y <= _downTransform.position.y)
            {
                _changeDirection = false;
            }
            if (_changeDirection)
            {
                transform.position = Vector2.MoveTowards(transform.position, _downTransform.position, _downpwardSpeed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, _upTransform.position, _uppwardSpeed * Time.deltaTime);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<IHealth>() != null)
        {
            collision.gameObject.GetComponent<IHealth>().TakeDamage(3);
        }
    }
}
