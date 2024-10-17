using UnityEngine;

namespace Code.Scripts.Player
{
    public class PlayerAnimator : MonoBehaviour
    {
        private Animator _animator;

        void Awake()
        {
            _animator = GetComponent<Animator>(); 
            _animator.Play(PlayerAnimationConstants.IDLE);
        }

        public void PlayAnimation(string animationName)
        {
            _animator?.Play(animationName);
        }
    }

    public static class PlayerAnimationConstants
    {
        public const string IDLE = "Sprite-Idle_Clip";
        public const string WALK = "Walk";
        public const string RUN = "Sprite-move_Clip";
        public const string AIR = "JumpMid";
        public const string JUMP = "Sprite-Jump_Clip";
        public const string ATTACK = "ComboAttack01";
        public const string DASH = "Dash";
    }
}