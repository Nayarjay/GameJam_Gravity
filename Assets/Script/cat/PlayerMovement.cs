using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController2D controller;
    public float runSpeed = 40f;
    float honrizontalMove = 0f;
    bool jump = false;
    public Animator animator;
    

    private Rigidbody2D rb;
    private Transform selfTransform;

    public float dashForce = 10f;
    private bool canDash = true;
    private bool isDashing = false;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;


    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        selfTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDashing) return;

       honrizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        Jump();
        animatorGestionner();
    }
    private void FixedUpdate()
    {
        controller.Move(honrizontalMove * Time.fixedDeltaTime, false,jump);
        jump = false;
    }
     public void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            animator.SetBool("IsJumping", false);
            animator.Play("Rush");


            // Calcul de la direction de dash en fonction de la rotation de l'objet lui-même
            Vector2 dashDirection = selfTransform.right;

            // Appliquer la force de dash au Rigidbody de l'objet

            StartCoroutine(Dash());

        }
    }
    public void animatorGestionner()
    {
        animator.SetFloat("Speed", Mathf.Abs( honrizontalMove));
    }
    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashForce, 0f);
        yield return new WaitForSeconds(dashingTime);
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}
