using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

  [SerializeField]
  private float speed = 3;
  private bool isGrounded = true;
  private float jumpHeight = 200.0f;
  private Rigidbody rigidbody;

  void Start()
  {
    rigidbody = GetComponent<Rigidbody>();
  }

  void Update()
  {
    Vector3 moveDirection =
        new Vector3(-Input.GetAxis("Vertical"),
              +0,
              +Input.GetAxis("Horizontal"))
              .normalized
        * Time.deltaTime
        * speed;
    Vector3 pointToLookAt = transform.position
                + moveDirection * 100;

    transform.position += moveDirection;
    transform.LookAt(pointToLookAt);

    if (isGrounded && Input.GetKeyDown(KeyCode.Space))
    {
      rigidbody.AddForce(Vector3.up * jumpHeight, ForceMode.Force);
    }
  }

  void OnCollisionEnter(Collision other)
  {
    if (other.gameObject.tag == "Ground")
    {
      isGrounded = true;
    }
  }


  void OnCollisionStay(Collision other)
  {
    if (other.gameObject.tag == "Ground")
    {
      isGrounded = true;
    }
  }

  void OnCollisionExit(Collision other)
  {
    if (other.gameObject.tag == "Ground")
    {
      isGrounded = false;
    }
  }
}
