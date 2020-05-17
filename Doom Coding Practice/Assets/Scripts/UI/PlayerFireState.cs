using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireState : StateMachineBehaviour {
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity)) {
            if (hit.collider.gameObject.tag == "Zombieman") {
                Debug.Log("Shot");
                Health zombieHealth = hit.collider.gameObject.GetComponent<Health>();
                zombieHealth.TakeDamage(hit.collider.gameObject);
            }
        }
    }
}
