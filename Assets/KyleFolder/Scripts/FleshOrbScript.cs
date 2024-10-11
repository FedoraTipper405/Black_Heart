using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleshOrbScript : MonoBehaviour
{
    private GameObject _player;
    private Rigidbody2D rb;
    [SerializeField]
    private float _force;
    [SerializeField]
    private float _timer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = _player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * _force;
    }


    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > 3)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<IHealth>() != null)
        {
            collision.gameObject.GetComponent<IHealth>().TakeDamage();
            Destroy(gameObject);
        }
    }
}
