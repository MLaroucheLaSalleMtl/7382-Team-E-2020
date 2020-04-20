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
        if (this.gameObject.name == "Health Bar")
        {
            this.GetComponent<Slider>().value = instance.Hp / 100;  // health bar for player
        }
        else if (this.gameObject.name == "BossHealth")
        {

        }

    }

}
