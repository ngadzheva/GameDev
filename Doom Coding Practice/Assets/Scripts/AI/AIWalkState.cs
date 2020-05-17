using System.Collections;
using System.Collections.Generic;
using static UnityEngine.Mathf;
using UnityEngine;

public class AIWalkState : StateMachineBehaviour {
  [SerializeField]
	[Range(1.0f, 5.0f)]
	private float wantedDistance = 2.0f;
  override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
      float moveDirection = -Sign(animator.transform.localScale.x);
      animator.gameObject.transform.Translate(animator.gameObject.transform.position.x + wantedDistance, animator.gameObject.transform.position.y, animator.gameObject.transform.position.z);
  }

  private void HitPlayer() {
      GameObject zombieman = GameObject.FindWithTag("Zombieman");
      Transform transform = zombieman.transform;
      Ray ray = new Ray(transform.position, -transform.forward);
      RaycastHit hit;

      if (Physics.Raycast(ray, out hit, Mathf.Infinity)) {
          if (hit.collider.gameObject.tag == "Player") {
              Health playerHealth = hit.collider.gameObject.GetComponent<Health>();
              GameObject playerHead = GameObject.FindWithTag("Head");
              playerHealth.TakeDamage(playerHead);
          }
      }
  }
}
