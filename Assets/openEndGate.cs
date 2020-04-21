using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class openEndGate : MonoBehaviour
{
    [SerializeField] private GameObject openGate;
    bool triggerStay = false;


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            triggerStay = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            triggerStay = false;
            openGate.SetActive(false);

        }
    }

    private void Update()
    {

        if (triggerStay && Input.GetKeyDown(KeyCode.T))
        {
            openGate.SetActive(!openGate.activeSelf);
            
            SceneManager.LoadScene("Menu");
            Debug.Log("quit");
        }
       
    }
    

}
