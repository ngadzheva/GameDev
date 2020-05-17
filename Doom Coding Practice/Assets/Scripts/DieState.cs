using UnityEngine;

public class DieState : StateMachineBehaviour {
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		animator.SetBool("IsDying", true);

		if (animator.gameObject.tag == "Zombieman") {
			Destroy(animator.gameObject, 1.0f);
		} else {
			Destroy(GameObject.FindWithTag("Weapon"));
		}
	}
}
