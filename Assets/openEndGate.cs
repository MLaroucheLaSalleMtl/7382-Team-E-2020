using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openEndGate : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject openEndDoor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            openEndDoor.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            openEndDoor.SetActive(false);
        }
    }
}
