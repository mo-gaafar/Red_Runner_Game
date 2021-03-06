using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public CharacterController2D controller;
    public Animator animator;
    public Rigidbody2D rb;

    public float runSpeed = 40f;
    float horizontalMove = 0f;

    bool crouch = false;
    bool jump = false;

    // Update is called once per frame
    void Update () {
        horizontalMove = Input.GetAxisRaw ("Horizontal") * runSpeed;
        animator.SetFloat ("Speed", Mathf.Abs (horizontalMove));

        if (Input.GetButtonDown ("Jump")) {
            jump = true;
            animator.SetBool ("isJumping", true);
        }

        if (Input.GetButtonDown ("Crouch")) {
            crouch = true;
        } else if (Input.GetButtonUp ("Crouch")) {
            crouch = false;
        }
    }

    public void OnLanding () {
        animator.SetBool ("isJumping", false);
    }

    void FixedUpdate () {
        //Moves our character
        //fixedDeltaTime is the time elapsed since the last fixedupdate call
        controller.Move (horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;

        if (rb.position.y < -10f) {
            FindObjectOfType<GameManager> ().EndGame ();
        }

    }
}