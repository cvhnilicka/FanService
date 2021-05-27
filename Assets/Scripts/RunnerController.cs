using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerController : MonoBehaviour
{

    CapsuleCollider2D myCollider;
    Animator animator;

    private Vector2 slideColliderOffset = new Vector2(0,-1.28f);
    private Vector2 slideColliderSize = new Vector2(1.1f,1.47f);

    private Vector2 jumpColliderOffset = new Vector2(0, 1.25f);
    private Vector2 jumpColliderSize = new Vector2(1.1f, 1.64f);

    private Vector2 regColliderOffset = new Vector2(0, 0.235f);
    private Vector2 regColliderSize = new Vector2(1.1f, 3.59f);


    // state
    private bool isSliding;
    private bool isJumping;

    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
        isSliding = false;
        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        Slide();
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
        }
    }

}
