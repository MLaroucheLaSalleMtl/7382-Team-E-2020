using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    // COMPONENTS
    private Animator anim;
    private Rigidbody2D rigid;
    private SpriteRenderer sprite;

    // MOVEMENT
    private Vector2 move = new Vector2();
    private Vector3 pos = new Vector3();
    private Vector3 zeroVelocity = Vector3.zero;

    [SerializeField] private float speed = 5f;
    [SerializeField] private float smoothing = 0.1f;
    [SerializeField] private float jumpForce = 20f;

    private bool run;
    private bool jump = false;
    private bool isGrounded = false;

    public bool Run { get => run; }


    // MOVEMENT METHODS ==============================================
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = collision.gameObject.tag == "Map";
    }

    public void OnJump(InputAction.CallbackContext context){
        jump = (context.ReadValue<float>() > 0);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        run = (context.ReadValue<float>() > 0);
    }



    // START & UPDATE ==================================================
    void Start()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        rigid.velocity = MovePlayer();

        if(jump)
        {
            rigid.AddForce(new Vector2(0, jumpForce));
            isGrounded = false;
        }

        anim.SetBool("Grounded", isGrounded);
        anim.SetFloat("Walk", Math.Abs(move.x));
        anim.SetBool("Run", Run);
    }



    // OTHER METHODS ======================================================
    private Vector3 MovePlayer()
    {
        pos.x = (Run && isGrounded) ? move.x * (speed * 2) : move.x * speed;

        return Vector3.SmoothDamp(rigid.velocity, pos, ref zeroVelocity, smoothing);

    }
}
