 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] private BoxCollider2D collider;
    public Animator animator;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            animator.SetBool("open", true);
            animator.SetBool("close", false);
            Invoke("DestroyObject", 1.5f);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            animator.SetBool("close", true);
            animator.SetBool("open", false) ;
            Invoke("EnableCollider", 1.5f);

        }
    }

    private void DestroyObject()
    {
        collider.enabled = false;

    }

    private void EnableCollider()
    {
        collider.enabled = true;

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
