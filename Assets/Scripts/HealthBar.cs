using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private GameManager instance;
    public Slider slider;

    private void Start()
    {
        instance = GameManager.instance;
    }

    void Update()
    {
        // Debug.Log(instance.Hp);
        this.GetComponent<Slider>().value = instance.Hp / 100;
    }

    ////Changes the maximum health, allowing an increase in capacity without messing with the gui.
    //public void SetMaxHealth(float hp)
    //{
    //    slider.maxValue = hp;
    //    slider.value = hp;
    //}
    ////Changes the current health value, moving the gui proportionally.
    //public void SetHealth(float hp)
    //{
    //    slider.value = hp;
    //}

}
