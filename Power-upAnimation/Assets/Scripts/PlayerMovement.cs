﻿using UnityEngine;
using static UnityEngine.Mathf;

[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour {
	[SerializeField]
	[Range(0, 5)]
	private float moveSpeed = 3;

	[SerializeField]
	[Range(0.1f, 2)]
	public float gravity = 0.5f;

	private bool isCrouching = false;
	private bool isJumping = false;
	private readonly float movementThreshold = 0.01f;
	private int fallSpeed = 30;
	private Vector2 velocity = Vector2.zero;

	[SerializeField]
	private KeyCode jumpKey = KeyCode.W;

	[SerializeField]
	private KeyCode crouchKey = KeyCode.S;

	private Animator animator;
	private new Rigidbody2D rigidbody;
	private GameObject mushroom;
	private Animator mushroomAnimator;

	void Start() {
		animator = GetComponent<Animator>();
		rigidbody = GetComponent<Rigidbody2D>();
		mushroom = GameObject.FindWithTag("Mushroom");
		mushroomAnimator = mushroom.GetComponent<Animator>();
	}

	void Update() {
		isCrouching = Input.GetKey(crouchKey);
		if (!isJumping) {
			animator.SetBool("IsCrouching", isCrouching);
			if (isCrouching) {
				return;
			}
		}

		velocity.x = Input.GetAxis("Horizontal");
		animator.SetFloat("HorizontalMovement", Abs(velocity.x));

		if (Abs(velocity.x) > movementThreshold) {
			transform.localScale = new Vector3(Sign(velocity.x), 1, 1);
		}

		if (!isJumping && Input.GetKeyDown(jumpKey)) {
			velocity.y = 1;
			isJumping = true;
			animator.SetBool("IsJumping", true);
		}

		rigidbody.MovePosition(rigidbody.position + velocity * moveSpeed * Time.deltaTime);

		if (isJumping) {
			velocity.y -= gravity * Time.deltaTime;
		}
	}

	private void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.CompareTag("Floor")) {
			isJumping = false;
			animator.SetBool("IsJumping", false);
			velocity.y = 0;
		}

		if (collision.gameObject.CompareTag("Block")) {
			var normal = collision.contacts[0].normal;
			if (normal.y > 0) {
				isJumping = false;
				velocity.y = 0;
			}

			animator.SetBool("IsJumping", false);
		}
	}

	private void OnCollisionExit2D(Collision2D collision) {
		if (collision.gameObject.CompareTag("Block")) {
			velocity.y -= fallSpeed * Time.deltaTime;
		}
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag("Mushroom")) {
			bool isMushroomMoving = mushroomAnimator.GetBool("IsMoving");

			if (isMushroomMoving) {
				animator.runtimeAnimatorController = Resources.Load("Animations/Mario/Big Mario/BigMario") as RuntimeAnimatorController;
				Destroy(mushroom);
			}
		}
	}
}
