using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dummyplayer : MonoBehaviour
{
    private GameManager instance;
    private int maxHealth = 100;
    private float currentHealth;
    private int maxStamina = 100;
    private float currentStamina;
    [SerializeField] private Slider staminaBar;
    private bool recentlyDrained;
    private float regenTimer;

    public bool staminaFull()
    {
        return (this.currentStamina == maxStamina);
    }


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        currentStamina = maxStamina;
        staminaBar.value = 1;
        instance = GameManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKey(KeyCode.Space))
        // {
        //     StaminaDrain(0.3f);
        // }

        currentStamina = instance.Stamina;
        staminaBar.value = currentStamina/10;

        Debug.Log(currentStamina);        

        // if (Input.GetKey(KeyCode.LeftShift))
        // {
        //     recentlyDrained = false;
        // }

        // if (!recentlyDrained & !staminaFull())
        // {
        //     StaminaRegen();
        // }

        // if (recentlyDrained == true)
        // {
        //     regenTimer += Time.deltaTime;
        //     if (regenTimer >  3f)
        //     {
        //         recentlyDrained = false;
        //     }
        // }
    }

    public void StaminaDrain(float drain)
    {
        recentlyDrained = true;
        if (currentStamina >= drain)
        {
            currentStamina -= drain;
            
        }
        //lastDrained = Time.time;
        regenTimer = 0;
    }

    void StaminaRegen()
    {
        if (!((currentStamina += 0.1f) > maxStamina))
        {
            currentStamina += 0.1f;
            //staminaBar.SetStamina(currentStamina);
        }
        else
        {
            currentStamina = maxStamina;
            //staminaBar.SetStamina(currentStamina);
        }
    }
}
