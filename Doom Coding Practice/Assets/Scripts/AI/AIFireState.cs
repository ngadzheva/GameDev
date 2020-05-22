using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFireState : StateMachineBehaviour {
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        animator.SetTrigger("ShouldBackOff");
        HitPlayer();
    }

    private void HitPlayer() {
        GameObject zombieman = GameObject.FindWithTag("Zombieman");
        Transform transform = zombieman.transform;
        Ray ray = new Ray(transform.position, transform.forward);
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
