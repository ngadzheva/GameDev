using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class BoxMovement : MonoBehaviour {
    private Animator animator;
	private new Rigidbody2D rigidbody;
    private GameObject mushroom;
    private Animator mushroomAnimator;

    private bool isMoving = false;
    private bool isMushroomMoving = false;

    void Start() {
        animator = GetComponent<Animator>();
		rigidbody = GetComponent<Rigidbody2D>();
        mushroom = GameObject.FindWithTag("Mushroom");
        mushroomAnimator = mushroom.GetComponent<Animator>();
    }

    void Update() {
        if (!isMoving) {
            animator.SetBool("IsMoving", isMoving);
        }

        if (!isMushroomMoving && mushroom) {
            mushroomAnimator.SetBool("IsMoving", isMushroomMoving);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")) {
            var normal = other.contacts[0].normal;

            if (normal.y > 0) {
                isMoving = true;
                isMushroomMoving = true;
                animator.SetBool("IsMoving", isMoving);

                if (mushroom) {
                    mushroomAnimator.SetBool("IsMoving", isMushroomMoving);
                }
            }
        }
    }
}
