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
        if (col.tag == "Player" && this.gameObject.name =="FirstRadio")
        {

            animator.SetBool("DialogueOne", true);
            Invoke("DestroyObject", 15f);
        }
        if (col.tag == "Player" && this.gameObject.name == "SecondRadio")
        {

            animator.SetBool("DialogueTwo", true);
            Invoke("DestroyObject", 15f);
        }
        if (col.tag == "Player" && this.gameObject.name == "ThirdRadio")
        {

           animator.SetBool("DialogueThree", true);
           Invoke("DestroyObject", 15f);
        }
        if (col.tag == "Player" && this.gameObject.name == "FourthRadio")
        {

            animator.SetBool("DialogueFour", true);
            Invoke("DestroyObject", 8f);
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
