using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open : MonoBehaviour
{
    public Animator OpenDoor;

    // Start is called before the first frame update
    void Start()
    {
        OpenDoor = GetComponent<Animator>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            OpenDoor.SetBool("Open",true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            OpenDoor.SetBool("Open", false);
        }
    }
}
