using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RunnerController : MonoBehaviour
{

    CapsuleCollider2D myCollider;
    Animator animator;
    Rigidbody2D myBody;

    private Vector2 slideColliderOffset = new Vector2(0,-1.28f);
    private Vector2 slideColliderSize = new Vector2(1.1f,1.47f);

    private Vector2 jumpColliderOffset = new Vector2(0, 1.25f);
    private Vector2 jumpColliderSize = new Vector2(1.1f, 1.64f);

    private Vector2 regColliderOffset = new Vector2(0, 0.1213031f);
    private Vector2 regColliderSize = new Vector2(1.1f, 3.807394f);



    private Vector3 startingPos;

    // state
    private bool isSliding;
    private bool isJumping;

    private float jumpTime = 0.4f;
    private float jumpTimer;

    public Vector2 jumpVel = new Vector2(0f, 1750f);


    public bool btnjump;
    public bool btnslide;

    private bool isDead;

    [SerializeField] GameOverController gameOver;
    [SerializeField] ScoreUIController myUI;






    // Start is called before the first frame update
    void Start()
    {

        myCollider = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
        myBody = GetComponent<Rigidbody2D>();
        isSliding = false;
        isJumping = false;
        jumpTimer = -99f;
        startingPos = transform.localPosition;
        btnjump = false;
        btnslide = false;
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            Slide();
            Jump();
            if (isJumping)
            {
                JumpTimer();

            }
        }
        else
        {
            // todo: dead stuff
            
        }



    }

    void Slide()
    {
        if ((Input.GetKey(KeyCode.LeftShift) || btnslide) && !isSliding)
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
        if ((Input.GetKeyDown(KeyCode.Space) || btnjump) && myBody.IsTouchingLayers(LayerMask.GetMask("ground")))
        {
            myCollider.size = jumpColliderSize;
            myCollider.offset = jumpColliderOffset;
            isJumping = true;
            jumpTimer = jumpTime;
            myBody.AddRelativeForce(jumpVel);
            animator.SetBool("IsJumping", isJumping);
            btnjump = false;

        }
    }

    public void SetBtnJump()
    {
        this.btnjump = true;
    }
    public void DoneSliding()
    {
        this.btnslide = false;
        isSliding = false;
        animator.SetBool("IsSliding", isSliding);
        myCollider.size = regColliderSize;
        myCollider.offset = regColliderOffset;
    }

    public void SetSlideJump()
    {
        this.btnslide = true;
    }

    void JumpTimer()
    {
        if (jumpTimer <= 0f && isJumping)
        {
            isJumping = false;
            //transform.localPosition = startingPos;
            animator.SetBool("IsJumping", isJumping);
            myCollider.size = regColliderSize;
            myCollider.offset = regColliderOffset;

        }
        else if (jumpTimer > 0f && isJumping)
        {
            jumpTimer -= Time.deltaTime;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "hit")
        {
            isDead = true;
            // todo: display the gameoverui
            // remove the button
            myUI.KillScoreUpdate();
            float s = myUI.GetScore();
            myUI.gameObject.SetActive(false);
            gameOver.ActivateGameOver();
            gameOver.SetFinalScore(s);
            
            
        }

    }




}
