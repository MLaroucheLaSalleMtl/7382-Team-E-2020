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
    private bool run;


    // MOVEMENT METHODS ==============================================
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
        anim.SetFloat("Walk", Math.Abs(move.x));
        anim.SetBool("Run", run);
    }



    // OTHER METHODS ======================================================
    private Vector3 MovePlayer()
    {
        pos.x = (run) ? move.x * (speed * 2) : move.x * speed;
        pos.y = this.transform.position.y;

        if (move.x < 0) sprite.flipX = true;
        if (move.x > 0) sprite.flipX = false;

        return Vector3.SmoothDamp(rigid.velocity, pos, ref zeroVelocity, smoothing);

    }
}
