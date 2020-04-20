using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    private GameManager instance;

    private Rigidbody2D npc;
    private Animator anim;
    
    [SerializeField] private float speed = 3f;
    private Transform player;

    private Vector2 move;
    private Vector3 zeroV = Vector3.zero;

    private bool isGrounded = false;
    private bool playerDetected = false;

    public bool PlayerDetected { get => playerDetected; set => playerDetected = value; }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = collision.gameObject.tag == "Ground";
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = collision.gameObject.tag != "Ground";
    }


    // Start is called before the first frame update
    void Start()
    {
        npc = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        instance = GameManager.instance;
        instance.AmountOfEnemies++;
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        FollowPlayer();


        anim.SetBool("Walk", move.x != 0);

        //Flip sprite
        if (move.x < 0) GetComponent<SpriteRenderer>().flipX = true;
        else if (move.x > 0) GetComponent<SpriteRenderer>().flipX = false;

        if (!isGrounded)
        {
            npc.velocity = new Vector2(0, -1.5f);
        }
        else

        {
            npc.velocity = Vector3.SmoothDamp(npc.position, move, ref zeroV, 0.001f);
        }

    }




    private void FollowPlayer()
    {
        //RaycastHit2D hitLeft = Physics2D.Raycast(this.transform.position,
        //    new Vector2(this.transform.position.x - 5, this.transform.position.y), 15f);
        //RaycastHit2D hitRight = Physics2D.Raycast(this.transform.position,
        //    new Vector2(this.transform.position.x + 5, this.transform.position.y), 15f);

        //Debug.DrawRay(this.transform.position,
        //    new Vector3(this.transform.position.x - 20, this.transform.position.y), Color.red);

        if (playerDetected)
        {

            if (this.transform.position.x != player.position.x)
            {
                if (player.position.x - transform.position.x > 0)
                {
                    move.x = 1 * speed / 10;
                }
                else if (player.position.x - transform.position.x < 0)
                {
                    move.x = -1 * speed / 10;
                }
            }
        }

        

    }
}
