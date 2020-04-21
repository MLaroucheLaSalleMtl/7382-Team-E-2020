using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControlEnd : MonoBehaviour
{
    private Vector2 move;
    [SerializeField] private float speed = 2f;
    private Rigidbody2D movement;
    private Animator anim;
    private bool run = false;
    private bool runDefault = false;
    private bool isGrounded = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = collision.gameObject.tag == "Ground";
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = collision.gameObject.tag == "Ground";
    }

    private void Start()
    {
        movement = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        run = (Mathf.Abs(context.ReadValue<float>()) > 0);
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        // INTERACT CODE HERE
    }

    private void Update()
    {

        if (isGrounded)
        {
            if (move.x < 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else if (move.x > 0)
            {
                GetComponent<SpriteRenderer>().flipX = false;

            }
        }
        else
        {
            move.x = 0;
            move.y = -1.5f;
        }

        

        movement.velocity = (run) ? move * speed * 4 * Time.deltaTime : 
                                    move * speed * Time.deltaTime;

        anim.SetBool("Run", run);

        anim.SetFloat("Walk", Mathf.Abs(move.x));

    }
}
