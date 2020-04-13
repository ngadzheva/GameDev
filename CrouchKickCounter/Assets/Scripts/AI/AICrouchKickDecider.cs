using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICrouchKickDecider : StateMachineBehaviour {
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
			} 
		}
  }
}
