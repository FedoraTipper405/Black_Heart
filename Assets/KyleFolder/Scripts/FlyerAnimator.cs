using Code.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyerAnimator : MonoBehaviour
{
    private Animator _animator;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _animator.Play(FlyerAnimationConstants.IDLE);
    }

    public void PlayAnimation(string animationName)
    {
        _animator?.Play(animationName);
    }
}

public static class FlyerAnimationConstants
{
    public const string CHASE = "Sprite-FlyingEnemy2Movement_Clip";
    public const string IDLE = "IdleFlyerAnimation";
}
