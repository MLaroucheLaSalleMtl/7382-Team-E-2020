using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class summaryScript : MonoBehaviour
{
    private bool GameIsPaused = false;

    private SpriteRenderer sprite;

    bool interactable = false;

    public void OnRead(InputAction.CallbackContext context)
    {
        ShowSprite();
    }

    public void ShowSprite()
    {
        if(interactable)
        {
            sprite.enabled = !sprite.enabled;
        }

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            interactable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            sprite.enabled = false;
            interactable = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
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
