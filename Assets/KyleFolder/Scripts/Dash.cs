using Code.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public bool canDash = true;
    public bool isDashing;
    public float dashingPower;
    public float dashingTime = 0.2f;
    public float dashingCoolDown = 2f;
    [SerializeField]
    Rigidbody2D rb;

    private Animator _animator;
    void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    void Start()
    {

    }


    void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            _animator.Play(PlayerAnimationConstants.DASH);
            StartCoroutine(Dashing());
        }
    }

    private IEnumerator Dashing()
    {
        canDash = false;
        isDashing = true;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 2f);
        yield return new WaitForSeconds(dashingTime);
        isDashing = false;
        yield return new WaitForSeconds(dashingCoolDown);
        canDash = true;
    }
}
