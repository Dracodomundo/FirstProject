using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Controller : MonoBehaviour
{
    Rigidbody2D rigidBody;
    public float moveSpeed = 10f;

    public bool isFacingRight = true;
    Animator anim;

    bool isGrounded = false;

    public Transform groundCheck;

    float groundRadius = 0.2f;

    public LayerMask whatIsGround;


    void Start()
    {
        anim = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();

       
    }

    void FixedUpdate()
    {
        Run();

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("Ground", isGrounded);
        anim.SetFloat("vSpeed", rigidBody.velocity.y);
        if (!isGrounded)
            return;
    }

    public void Run()
    {
        float move = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(move));


        rigidBody.velocity = new Vector2(move * moveSpeed, rigidBody.velocity.y);
        if (move > 0 && !isFacingRight)
            Flip();
        else if (move < 0 && isFacingRight)
            Flip();
    }
   
    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "floatPlatform") 
            transform.parent = col.transform;
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.transform.tag == "floatPlatform") 
            transform.parent = null;
    }
    void Update()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Ground", false);
            rigidBody.AddForce(new Vector2(0, 280));
        }
    }
}
