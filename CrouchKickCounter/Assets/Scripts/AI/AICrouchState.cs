using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICrouchState : StateMachineBehaviour {

    private MovementController movementController;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        movementController = animator.GetComponent<MovementController>();
        movementController.SetHorizontalMoveDirection(0);

        Transform player = GameObject.FindWithTag("Player").transform;
        float direction = player.position.x - animator.transform.position.x;
        movementController.TurnTowards(direction);

        animator.SetTrigger("ShouldCrouchKick");
    }
}
