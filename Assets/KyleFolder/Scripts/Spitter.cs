using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spitter : Enemy
{
    public GameObject _fleshOrb;
    public Transform _fleshOrbPos;
    public float _radius;

    private float _timer;
    public Transform player;
    void Start()
    {

    }

    protected override void Update()
    {
        base.Update();

        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < _radius)
        {
            _timer += Time.deltaTime;

            if (_timer > 4)
            {
                _timer = 0;
                ShootOrb();
            }
        }
    }

    void ShootOrb()
    {
        Instantiate(_fleshOrb, _fleshOrbPos.position, Quaternion.identity);
    }
}
