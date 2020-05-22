using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Mathf;

public class AICrouchKickState : StateMachineBehaviour {

    private Animator animator;
    private MovementController movementController;
    private GameObject hitbox;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        this.animator = animator;
        float direction = Sign(animator.transform.localScale.x);
        movementController = animator.GetComponent<MovementController>();
        movementController.SetHorizontalMoveDirection(direction);
        hitbox = animator.transform.GetChild(0).gameObject;
        hitbox.SetActive(true);

        animator.SetTrigger("Landed");
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		hitbox.SetActive(false);
	}
}
