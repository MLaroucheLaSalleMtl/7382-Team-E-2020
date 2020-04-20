using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class flashLight : MonoBehaviour
{

    public static bool FlashLight = false;
    public GameObject BlueFlash;

    public void OnFlashLightUse(InputAction.CallbackContext context)
    {
        if (GameObject.Find("GameObject").GetComponent<ChoiceScript>().ChoiceMade == 2)
        {
            if (FlashLight)
            {
                TurnOff();
            }
            else
            {
                TurnOn();
            }
        }
    }



    // Update is called once per frame
    void Update()
    {
    }

    public void TurnOff()
    {
        BlueFlash.SetActive(false);
        FlashLight = false;
    }

    public void TurnOn()
    {
        BlueFlash.SetActive(true);
        FlashLight = true;
    }
}
