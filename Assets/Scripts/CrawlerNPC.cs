using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrawlerNPC : MonoBehaviour
{
    [SerializeField] private float health = 60f;
    private float MaxHp;

    public float Health { get => health;}

    // Start is called before the first frame update
    void Start()
    {
        MaxHp = health;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            GetComponent<Animator>().SetBool("Dead", true);
            GetComponent<MonsterAI>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            GetComponent<Rigidbody2D>().simulated = false;
            Invoke("Death", 5f);
        }
        // Debug.Log(health);
    }

    private void Death()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(float dmg)
    {
        this.health -= dmg;
    }
}
