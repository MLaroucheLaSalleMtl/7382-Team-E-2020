using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class summaryScript : MonoBehaviour
{
    public bool GameIsPaused = false;
    public GameObject readScript;

    bool interactable;

    public void OnRead(InputAction.CallbackContext context)
    {
        // if (interactive.interactive)
        // {
        //     readScript.SetActive(!readScript.activeInHierarchy); //toggle system 
        // }
        if(interactable)
        {
            readScript.SetActive(!readScript.activeInHierarchy);
        }
        else
        {
            readScript.SetActive(false);
        }

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.tag);
        if(col.tag == "Player")
        {
            interactable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            readScript.SetActive(false);
            interactable = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
