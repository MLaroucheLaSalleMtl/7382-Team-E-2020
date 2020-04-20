using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxScript : MonoBehaviour
{

    [SerializeField] private float health = 10f;
    private float MaxHp;

    public float Health { get => health; }

    // Start is called before the first frame update
    void Start()
    {
        MaxHp = health;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 5f)
        {
            GetComponent<Collider2D>().enabled = false;
            Invoke("Death", 10f);
        }
        
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
