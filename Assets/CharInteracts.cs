using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharInteracts : MonoBehaviour
{
    private bool fire = false;
    public void OnShoot(InputAction.CallbackContext context)
    {
        Debug.Log(context.ReadValue<float>() > 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(fire);
    }
}
