using UnityEngine;

public class AIDeciderState : StateMachineBehaviour {

  override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		float rand = Random.value;
		GameObject player = GameObject.FindWithTag("Player");

		if (player == null) {
			Debug.LogError("No GameObject with the \"Player\" tag found");
		} else {
			Animator playerAnimator = player.GetComponent<Animator>();

			if (playerAnimator.GetCurrentAnimatorStateInfo(layerIndex).IsName("Monk_Punch")) {
				if (rand <= 0.8f) {
					animator.SetTrigger("ShouldCrouch");
				}
			} else {
				if (rand <= 0.2f) { animator.SetBool("ShouldRetreat", true); }
				else if (rand <= 0.4f) { animator.SetTrigger("ShouldWait"); }
				else if (rand <= 1.0f) { animator.SetTrigger("ShouldAttack"); }
			}
		}
  }
}
