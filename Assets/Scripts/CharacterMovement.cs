using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    // COMPONENTS
    [SerializeField] Transform cross;
    [SerializeField] Sprite[] sprites;
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

    private bool run = false;
    private bool jump = false;
    private bool isGrounded = false;

    // AIMING
    private float radians;
    private float angle;

    private bool gunEquipped = true;

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
        // Debug.Log(move.x);

        rigid.velocity = MovePlayer();
        anim.enabled = !(move.x == 0 && move.y == 0);
        AimGun();

        if (jump)
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

    private void AimGun()
    {
        radians = cross.localPosition.y / cross.localPosition.x;
        angle = (sprite.flipX) ? -radians * (180 / Mathf.PI) : radians * (180 / Mathf.PI);

        if (angle < 20 && angle > 5)
            this.GetComponent<SpriteRenderer>().sprite = sprites[0];
        else if (angle > 20 && angle < 40)
            this.GetComponent<SpriteRenderer>().sprite = sprites[1];
        else if (angle > 40 && angle < 60)
            this.GetComponent<SpriteRenderer>().sprite = sprites[2];
        else if (angle > 60)
            this.GetComponent<SpriteRenderer>().sprite = sprites[3];
        else if (angle < 5 && angle > -20)
            this.GetComponent<SpriteRenderer>().sprite = sprites[4];
        else if (angle < -30)
            this.GetComponent<SpriteRenderer>().sprite = sprites[5];

    }
}
