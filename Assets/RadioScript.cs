using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioScript : MonoBehaviour
{
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
            animator.SetBool("DialogueOne", true);
            Invoke("DestroyObject", 10f);
        }
    }

    private void DestroyObject()
    {
        this.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
