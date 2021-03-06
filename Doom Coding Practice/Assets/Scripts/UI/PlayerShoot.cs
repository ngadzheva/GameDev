﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {
  [SerializeField]
  private int ammo = 100;

  private int frag = 0;
  private Animator animator;
  private Animator headAnimator;
  private Animator fireAnimator;
  private Animator zombiemanAnimator;
  private PlayerPointSystem ammoPoints;
  private PlayerPointSystem fragPoints;

  void Start() {
    animator = GetComponent<Animator>();
    headAnimator = GameObject.FindWithTag("Head").GetComponent<Animator>();
    zombiemanAnimator = GameObject.FindWithTag("Zombieman").GetComponent<Animator>();
    fireAnimator = GameObject.FindWithTag("Fire").GetComponent<Animator>();
    ammoPoints = GetComponent<PlayerPointSystem>();
    fragPoints = GetComponent<PlayerPointSystem>();
  }

  void Update() {
    if (Input.GetMouseButtonDown(0) && ammo > 0 && !headAnimator.GetBool("IsDying")) {
      animator.SetTrigger("ShouldFire");
      fireAnimator.SetTrigger("ShouldFire");
      headAnimator.SetTrigger("ShouldFire");

      UpdateAmmo();
      UpdateFrag();
    }
  }

  private void UpdateAmmo() {
    ammo -= 10;
    animator.SetInteger("Ammo", ammo);
    ammoPoints.UpdatePoints(ammo);
  }

  private void UpdateFrag() {
    if (zombiemanAnimator.GetBool("IsDying")) {
      frag += 10;
      fragPoints.UpdatePoints(frag);
    }
  }
}
