using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class summaryScript : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject readScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        readScript.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        readScript.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
