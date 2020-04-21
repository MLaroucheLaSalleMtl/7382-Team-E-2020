using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class quitGame : MonoBehaviour
{
    private void Update()
    {

        if (gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.T))
        {
            

            SceneManager.LoadScene("Menu");
            Debug.Log("quit");
        }

    }
}
