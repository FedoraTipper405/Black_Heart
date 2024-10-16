using Code.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    [SerializeField]
    private bool _canDash = true;
    [SerializeField]
    private bool _isDashing;
    [SerializeField]
    private float _dashingPower;
    [SerializeField]
    private float _dashingTime;
    [SerializeField]
    public float _dashCoolDown;
    [SerializeField]
    Rigidbody2D rb;
    private Animator _animator;
    public bool _disableDash;

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    void Start()
    {
        _disableDash = false;
    }


    void FixedUpdate()
    {
        if (_isDashing)
        {
            return;
        }
    }

    public void Dashing()
    {
        if (_canDash && _disableDash == false)
        {
            _animator.Play(PlayerAnimationConstants.DASH);
            StartCoroutine(IsDashing());
            AudioManager.PlaySound(SoundClip.Dash);
        }
    }

    private IEnumerator IsDashing()
    {
        _canDash = false;
        _isDashing = true;
        rb.velocity = new Vector2(transform.localScale.x * _dashingPower, 2f);
        yield return new WaitForSeconds(_dashingTime);
        _isDashing = false;
        yield return new WaitForSeconds(_dashCoolDown);
        _canDash = true;
    }
}
