using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CharacterMovement : MonoBehaviour
{
    private GameManager instance;

    // COMPONENTS
    [SerializeField] Transform cross;
    [SerializeField] Sprite[] groundSprites;
    [SerializeField] Sprite[] midAirSprites;
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
    [SerializeField] private float airTime = 2f;


    [SerializeField] private float staminaDrainRate = 3f;
    [SerializeField] private float staminaRegenRate = 8f;
    [SerializeField] private float timeForRegen = 3f;
    [SerializeField] private float waitBeforeRun = 5f;

    private float currWait = 0;
    private float currTimeForRegen = 0;
    private bool canRegen = false;
    private bool canRun = true;

    private float currAirTime = 0;

    private bool run = false;
    private bool jump = false;
    private bool isGrounded = false;

    // AIMING
    private float radians;
    private float angle;


    public bool Run { get => run; }
    public Vector2 Move { get => move; }
    public bool IsGrounded { get => isGrounded; set => isGrounded = value;  }


    // MOVEMENT METHODS ==============================================
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // isGrounded = (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Enemy") ;
        if (isGrounded)
        {
            currAirTime = 0;
        }
        // Debug.Log(collision.gameObject.tag);

        if (collision.gameObject.tag == "Enemy")
        {
            instance.DamagePlayer(10);  // only one enemy so one damage only
            // anim.SetTrigger("Damaged");
            // Fix flinch after demo.
        }


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
        instance = GameManager.instance;
    }

    void FixedUpdate()
    {
        //RaycastHit2D hit = 
        //Physics2D.Raycast(this.transform.position, -Vector2.up, 25f, 11);
        //isGrounded = (hit.distance <= 0.245f );

        //Debug.Log(hit.distance);

        // Debug.Log(canRun);

        StaminaCheck();
        MoveOnShoot();
        AimGun();
        HandleStamina();

        if (jump)
        {
            if (currAirTime < airTime)
            {
                rigid.AddForce(new Vector2(0, jumpForce));
                currAirTime += Time.deltaTime;
            }
            //isGrounded = false;
        }

        anim.SetBool("Grounded", isGrounded);
        anim.SetFloat("Walk", Math.Abs(move.x));
        //anim.SetBool("WalkOpposite", WalkBack());
        anim.SetBool("Run", (Run && canRun));


    }

    // OTHER METHODS ======================================================

    private bool WalkBack()
    {
        if(move.x > 0 && sprite.flipX)
        {
            return true;
        }
        else if(move.x < 0 && !sprite.flipX)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void StaminaCheck()
    {
        if (instance.Stamina < 0)
        {
            canRun = false;
            Invoke("CanRun", 5f);
        }
    }

    private void CanRun()
    {
        canRun = true;
    }

    private void HandleStamina()
    {
        if(canRegen)
        {
            instance.RegenStamina(staminaRegenRate * Time.deltaTime);
        }
        else
        {
            if(currTimeForRegen >= timeForRegen)
            {
                canRegen = true;
                currTimeForRegen = 0;
            }
            else
            {
                currTimeForRegen += Time.deltaTime;
            }
        }
    }

    private void MoveOnShoot()
    {
        if (GetComponent<CharInteracts>().Count == 0)
        {
            rigid.velocity = MovePlayer();
            anim.enabled = (rigid.velocity != Vector2.zero && isGrounded);
        }
        else
        {
            //---------------------this is for after the demo------------------------------
            //if (!isGrounded)
            //{
            //    rigid.AddForce(new Vector2(-0.1f * cross.localPosition.x, -0.1f * cross.localPosition.y)
            //        , ForceMode2D.Impulse);
            //}
            if (!isGrounded)
            {
                rigid.velocity = MovePlayer();
            }
            anim.enabled = false;

        }
    }

    private Vector3 MovePlayer()
    {
        //pos.x = (Run && isGrounded) ? move.x * (speed * 2) : move.x * speed;

        if(Run && isGrounded)
        {
            pos.x = (canRun) ? move.x * (speed * 2) : move.x * speed;
        }
        else
        {
            pos.x = move.x * speed;
        }

        //stamina drain
        if(Run && move.x != 0 && IsGrounded && canRun) 
        {
            float staminaToDrain = staminaDrainRate * Time.deltaTime;
            instance.ReduceStamina(staminaToDrain);
            canRegen = false;
        }

        return Vector3.SmoothDamp(rigid.velocity, pos, ref zeroVelocity, smoothing);

    }

    private void AimGun()
    {
        radians = cross.localPosition.y / cross.localPosition.x;
        angle = (sprite.flipX) ? 
            -radians * (180 / Mathf.PI) : radians * (180 / Mathf.PI);

        if (isGrounded)
        {
            DetermineAim(groundSprites);
        }
        else
        {
            DetermineAim(midAirSprites);
        }
    }

    private void DetermineAim(Sprite[] sprites)
    {
        if (angle < 20 && angle > 5)
            this.GetComponent<SpriteRenderer>().sprite = sprites[0];
        else if (angle > 20 && angle < 30)
            this.GetComponent<SpriteRenderer>().sprite = sprites[1];
        else if (angle > 30 && angle < 40)
            this.GetComponent<SpriteRenderer>().sprite = sprites[2];
        else if (angle > 40 && angle < 50)
            this.GetComponent<SpriteRenderer>().sprite = sprites[3];
        else if (angle > 60 && angle < 70)
            this.GetComponent<SpriteRenderer>().sprite = sprites[4];
        else if (angle > 70)
            this.GetComponent<SpriteRenderer>().sprite = sprites[5];
        else if (angle < 5 && angle > -20)
            this.GetComponent<SpriteRenderer>().sprite = sprites[6];
        else if (angle < -20 && angle > -40)
            this.GetComponent<SpriteRenderer>().sprite = sprites[7];
        else if (angle < -40 && angle > -70)
            this.GetComponent<SpriteRenderer>().sprite = sprites[8];
        else if (angle < -70)
            this.GetComponent<SpriteRenderer>().sprite = sprites[9];
    }



}
