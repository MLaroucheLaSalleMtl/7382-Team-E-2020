using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class readMonitor : MonoBehaviour
{
    [SerializeField] private GameObject myMonitor;
    bool triggerStay = false;
 
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            triggerStay = true;
            Debug.Log("aaaa");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            triggerStay = false;
            myMonitor.SetActive(false);
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (triggerStay)
        {
            myMonitor.SetActive(!myMonitor.activeSelf);
        }
    }

    private void Update()
    {
        
    }
}
