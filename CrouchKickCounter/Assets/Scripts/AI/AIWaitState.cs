using UnityEngine;

public class AIWaitState : StateMachineBehaviour {

	private MovementController movementController;
	private Transform playerTransform;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    GameObject player = GameObject.FindWithTag("Player");

    Animator playerAnimator = player.GetComponent<Animator>();

    if (playerAnimator.GetCurrentAnimatorStateInfo(layerIndex).IsName("Monk_Punch")) {
      animator.SetTrigger("ShouldCrouch");
    }
    else {
      movementController = animator.GetComponent<MovementController>();
      movementController.SetHorizontalMoveDirection(0);
      playerTransform = player.transform;
    }
	}

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		float directionToPlayer = playerTransform.position.x - animator.transform.position.x;
		movementController.TurnTowards(directionToPlayer);
	}
}
