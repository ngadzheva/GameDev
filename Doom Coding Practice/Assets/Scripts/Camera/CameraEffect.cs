using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEffect : MonoBehaviour {
    Vignette vignette;
    Animator playerAnimator;
    void Start() {
        vignette = GetComponent<Vignette>();
        vignette.enabled = false;
        playerAnimator = GameObject.FindWithTag("Head").GetComponent<Animator>();
    }

    void FixedUpdate() {
        int playerHealth = playerAnimator.GetInteger("Health");

        if (playerHealth > 0 && playerHealth < 4) {
            if (!vignette.enabled) { vignette.enabled = true; }
            else { vignette.enabled = false; }
        } else if (playerHealth == 0) {
            vignette.enabled = true;
        }
    }
}
