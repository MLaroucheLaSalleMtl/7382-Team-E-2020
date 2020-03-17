using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedScript : MonoBehaviour
{
    CharacterMovement player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.IsGrounded = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        player.IsGrounded = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        player.IsGrounded = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<CharacterMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
