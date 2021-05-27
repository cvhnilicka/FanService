﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerController : MonoBehaviour
{

    CapsuleCollider2D myCollider;
    Animator animator;
    Rigidbody2D myBody;

    private Vector2 slideColliderOffset = new Vector2(0,-1.28f);
    private Vector2 slideColliderSize = new Vector2(1.1f,1.47f);

    private Vector2 jumpColliderOffset = new Vector2(0, 1.25f);
    private Vector2 jumpColliderSize = new Vector2(1.1f, 1.64f);

    private Vector2 regColliderOffset = new Vector2(0, 0.235f);
    private Vector2 regColliderSize = new Vector2(1.1f, 3.59f);



    private Vector3 movementVector = new Vector3(0f, 1.4f, 0);
    private Vector3 startingPos;
    float period = 0.5f;

    // state
    private bool isSliding;
    private bool isJumping;

    private float jumpTime = 0.4f;
    private float jumpTimer;
    float movementFactor;






    // Start is called before the first frame update
    void Start()
    {

        myCollider = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
        isSliding = false;
        isJumping = false;
        jumpTimer = -99f;
        startingPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        Slide();
        Jump();
        if (isJumping)
        {
            Oscalate();
            JumpTimer();

        }

    }

    void Slide()
    {
        if (Input.GetKey(KeyCode.LeftShift) && !isSliding)
        {
            myCollider.size = slideColliderSize;
            myCollider.offset = slideColliderOffset;
            animator.SetTrigger("Slide");
            isSliding = true;
            animator.SetBool("IsSliding", isSliding);

        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            // return to normal
            isSliding = false;
            animator.SetBool("IsSliding", isSliding);
            myCollider.size = regColliderSize;
            myCollider.offset = regColliderOffset;
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myCollider.size = jumpColliderSize;
            myCollider.offset = jumpColliderOffset;
            isJumping = true;
            jumpTimer = jumpTime;
            //myBody.
            animator.SetBool("IsJumping", isJumping);
        }
    }

    void JumpTimer()
    {
        if (jumpTimer <= 0f && isJumping)
        {
            isJumping = false;
            transform.localPosition = startingPos;
            animator.SetBool("IsJumping", isJumping);

        }
        else if (jumpTimer > 0f && isJumping)
        {
            jumpTimer -= Time.deltaTime;
        }
    }

    void Oscalate()
    {
        if (period <= Mathf.Epsilon) return;
        float cycles = Time.time / period; // grows continually from 0
        const float tau = Mathf.PI * 2;
        float rawSinWave = Mathf.Sin(cycles * tau);

        movementFactor = rawSinWave / 2f + 0.5f;

        Vector3 offset = movementVector * movementFactor;
        transform.position = offset + startingPos;
    }




}
