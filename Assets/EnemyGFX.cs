using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGFX : MonoBehaviour
{
    [SerializeField] private Transform player;
    private SpriteRenderer sprite;
    private Vector3 scale;

    public Vector3 Scale { get => scale;}

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        scale = transform.localScale;   // to pass on to TargetScript

        if (player.position.x < this.transform.position.x)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (player.position.x > this.transform.position.x)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
