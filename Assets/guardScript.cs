using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class guardScript : MonoBehaviour
{
    public GameObject keyGuard;
    private bool isStaying = false;

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (isStaying && !keyGuard.activeInHierarchy)
        {
            keyGuard.SetActive(true);
        }
        else
        {
            keyGuard.SetActive(false);
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" )
        {
            isStaying = true;
        }

    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            keyGuard.SetActive(false);
            isStaying = false;
        }
    }

}
