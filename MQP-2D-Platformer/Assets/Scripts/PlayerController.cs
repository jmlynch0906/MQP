using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    public SpriteRenderer sprite;
    public float speed = 5f;
    public float jumpHeight = 5f;
   [SerializeField] public bool isJumping;
    public AudioSource jumpSound;

    public float horizontalInput = 0f;

    [SerializeField] public float y = 0f;

    
    
    /*
    // Dashing
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 12f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;

    */
    //[SerializeField] private TrailRenderer tr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Movement
        horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
        
        y = rb.velocity.y;
        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            isJumping = true;
            rb.AddForce(new Vector2(0f, jumpHeight), ForceMode2D.Impulse);
            jumpSound.Play();
        }

        UpdateAnimation();

        // Dashing
       /* if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }
       */
    }

    private void UpdateAnimation(){

        if(horizontalInput>0f){
            anim.SetBool("Running",true);
            sprite.flipX = false;
        }
        else if (horizontalInput<0f){
            anim.SetBool("Running",true);
            sprite.flipX = true;
        }
        else{
            anim.SetBool("Running",false);
        }


    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            anim.SetBool("Grounded",true);
        }
    }

     private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
            anim.SetBool("Grounded",false);
        }
    }
    /*
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;

        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;

        if (rb.velocity.x < 0f)
        {
            dashingPower = -dashingPower;
        }

        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);

        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;

        rb.gravityScale = originalGravity;
        isDashing = false;

        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
    */
}
