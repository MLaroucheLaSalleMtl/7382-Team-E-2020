using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrawlerNPC : MonoBehaviour
{
    private GameManager instance;
    [SerializeField] private float health = 60f;
    private float MaxHp;
    private bool triggerOnce = false;

    public float Health { get => health;}

    // Start is called before the first frame update
    void Start()
    {
        MaxHp = health;
        instance = GameManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0 && !triggerOnce)
        {
            GetComponent<Animator>().SetBool("Dead", true);
            GetComponent<MonsterAI>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            GetComponent<Rigidbody2D>().simulated = false;
            Invoke("Death", 5f);
            triggerOnce = true;
        }
        // Debug.Log(health);
    }

    private void Death()
    {
        instance.AmountOfEnemies--;
        Destroy(gameObject);
    }

    public void TakeDamage(float dmg)
    {
        this.health -= dmg;
    }
}
