using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadPrisonerAnimator : MonoBehaviour
{
    private Animator _animator;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _animator.Play(DeadPrisonerAnimationConstants.IDLE);
    }

    public void PlayAnimation(string animationName)
    {
        _animator?.Play(animationName);
    }
}

public static class DeadPrisonerAnimationConstants
{
    public const string RUN = "Sprite-moveAlternatePlayer_Clip";
    public const string IDLE = "Sprite-IdleAltPlayer_Clip";
}
