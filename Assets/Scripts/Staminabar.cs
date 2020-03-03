using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Staminabar : MonoBehaviour
{
    private Slider slider;
    private GameManager instance;

    void Start()
    {
        instance = GameManager.instance;
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        slider.value = instance.Stamina / 100;
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
