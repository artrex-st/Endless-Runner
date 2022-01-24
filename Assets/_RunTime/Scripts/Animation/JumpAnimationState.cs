using UnityEngine;
public class JumpAnimationState : StateMachineBehaviour
{
    public delegate float AnimationJumpModifyHandler();
    public static event AnimationJumpModifyHandler OnAnimationJumpModifier;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        AnimatorClipInfo[] clips = animator.GetNextAnimatorClipInfo(layerIndex);
        float playerModifier = (float)OnAnimationJumpModifier?.Invoke();
        if (playerModifier != 0 && clips.Length > 0)
        {
            AnimatorClipInfo jumpClipInfo = clips[0];
            float multiplier = jumpClipInfo.clip.length / playerModifier;
            animator.SetFloat(PlayerAnimationConstants.JumpMultiplier, multiplier);
        }
    }
}
