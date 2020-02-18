using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharInteracts : MonoBehaviour
{
    private bool fire = false;

    public void OnShoot(InputAction.CallbackContext context)
    {
        fire = context.ReadValue<float>() > 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // tan x = OP/Adj
    // Update is called once per frame
    void Update()
    {
        

    }
}
