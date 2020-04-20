using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [SerializeField] GameObject player;
    [SerializeField] GameObject gameOverText;
    Scene sceneToLoad;

    private float hp = 100;
    private float stamina = 100;
    private int amountOfEnemies = 0;


    public int AmountOfEnemies { get => amountOfEnemies; set => amountOfEnemies = value; }

    public float Hp { get => hp; set => hp = value; }
    public float Stamina { get => stamina; set => stamina = value; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        sceneToLoad = SceneManager.GetActiveScene();
    }

    public void DamagePlayer(float damage)
    {
        // Debug.Log(hp);
        hp -= damage;
    }

    public void ReduceStamina(float drain)
    {
        // Debug.Log(Stamina);
        Stamina -= drain;
    }

    public void RegenStamina(float regen)
    {
        Stamina = (Stamina >= 100) ? Stamina + 0 : Stamina + regen;
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(sceneToLoad.name);
    }

    // Update is called once per frame
    void Update()
    {

    }
}