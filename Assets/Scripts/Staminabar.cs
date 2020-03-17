using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Staminabar : MonoBehaviour
{
    private Slider slider;
    private GameManager instance;
    private bool hideCalled = false;

    void Start()
    {
        instance = GameManager.instance;
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        slider.value = instance.Stamina / 100;
        if (slider.value == 1)
        {
            Invoke("HideSBar", 2f);
            hideCalled = true;
        }
        else if (hideCalled == true && slider.value != 1)
        {
            CancelInvoke("HideSBar");
            hideCalled = false;
        }
        else if (slider.value < 1)
        {
            slider.GetComponentInParent<Canvas>().enabled = true;

        }
    }

    void HideSBar()
    {
        slider.GetComponentInParent<Canvas>().enabled = false;
    }

    // //Changes the maximum stamina, allowing an increase in capacity without messing with the gui.
    // public void SetMaxStamina(float stamina)
    // {
    //     slider.maxValue = stamina;
    //     slider.value = stamina;
    // }
    // //Changes the current stamina value, moving the gui proportionally.
    // public void SetStamina(float stamina)
    // {
    //     slider.value = stamina;
    // }
}
