using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharInteracts : MonoBehaviour
{
    [SerializeField] Transform cross;
    [SerializeField] Sprite[] sprites;
    private bool fire = false;

    public void OnShoot(InputAction.CallbackContext context)
    {
        Debug.Log(context.ReadValue<float>() > 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // tan x = OP/Adj
    // Update is called once per frame
    void Update()
    {
        
        float radians = cross.localPosition.y/cross.localPosition.x;
        float angle = radians * (180/Mathf.PI);
        Debug.Log(angle);
        
        if(Mathf.Abs(angle) < 20){
        this.GetComponent<SpriteRenderer>().sprite = sprites[0];
        }
        else if(Mathf.Abs(angle) > 20 && Mathf.Abs(angle) < 40)
        {
        this.GetComponent<SpriteRenderer>().sprite = sprites[1];
        }
        else if(Mathf.Abs(angle) > 40 && Mathf.Abs(angle) < 60)
        {
        this.GetComponent<SpriteRenderer>().sprite = sprites[2];
        }
        else if(Mathf.Abs(angle) > 60)
        {
        this.GetComponent<SpriteRenderer>().sprite = sprites[3];
        }

    }
}
