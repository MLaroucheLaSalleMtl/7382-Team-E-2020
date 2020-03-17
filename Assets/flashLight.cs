using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashLight : MonoBehaviour
{

    public static bool FlashLight = false;
    public GameObject BlueFlash;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            if(FlashLight)
            {
                TurnOff();
            }
            else
            {
                TurnOn();
            }
        }
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
