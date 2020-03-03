using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    private Rigidbody2D npc;
    private Animator anim;
    
    [SerializeField] private float speed = 3f;
    [SerializeField] private Transform player;

    private Vector2 move;
    private Vector3 zeroV = Vector3.zero;

    //bool trigger = false;
    //private bool setAfterWait = true;
    //float startTime = 0;
    //float secondsOfWait = 3;

    // Start is called before the first frame update
    void Start()
    {
        npc = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //setAfterWait = false;
        // trigger = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // --------------------- after the demo
        //if (startTime < secondsOfWait && trigger)
        //{
        //    startTime += Time.deltaTime;
        //}
        //else
        //{
        //    setAfterWait = true;
        //    FollowPlayer();
        //}
        FollowPlayer();
        //Debug.Log(setAfterWait);

        anim.SetBool("Walk", move.x != 0);

        //Flip sprite
        if (move.x < 0) GetComponent<SpriteRenderer>().flipX = true;
        else if (move.x > 0) GetComponent<SpriteRenderer>().flipX = false;

        npc.velocity = Vector3.SmoothDamp(npc.position, move, ref zeroV, 0.001f);
    }




    private void FollowPlayer()
    {
        RaycastHit2D hitLeft = Physics2D.Raycast(this.transform.position,
            new Vector2(this.transform.position.x - 20, this.transform.position.y), 15f);
        RaycastHit2D hitRight = Physics2D.Raycast(this.transform.position,
            new Vector2(this.transform.position.x + 20, this.transform.position.y), 15f);

        if (hitLeft.collider.tag == "Player" || hitRight.collider.tag == "Player")
        {

            if (this.transform.position.x != player.position.x)
            {
                // -------------------- after the demo
                //if (hitRight.distance < 2 || hitLeft.distance < 2)
                //{
                //    startTime = 0;
                //    trigger = true;
                //    move.x = 0;
                //}
                if (Mathf.Abs(player.position.x - transform.position.x) < 0.4f &&
                                        Mathf.Abs(player.position.x - transform.position.x) > -0.4f)
                {
                    move.x = 0;
                }
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
