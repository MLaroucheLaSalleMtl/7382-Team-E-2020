using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class summaryScript : MonoBehaviour
{
    public bool GameIsPaused = false;
    public GameObject readScript;

    public CharInteracts interactive;

    public void OnRead(InputAction.CallbackContext context)
        {
        if (interactive.interactive)
        {
            readScript.SetActive(!readScript.activeInHierarchy); //toggle system 
        }


        if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
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
