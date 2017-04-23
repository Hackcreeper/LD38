using LD38;
using UnityEngine;

public class SpaceshipAnimationState : StateMachineBehaviour
{
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.normalizedTime >= 1f && !Main.Get.HasGameStarted)
        {
            animator.enabled = false;
            Main.Get.StartGame();
        }
    }
}
