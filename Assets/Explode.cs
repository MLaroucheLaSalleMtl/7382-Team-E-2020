using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Explode : MonoBehaviour
{
    [SerializeField] float timeForExplode = 3f;
    private Animator animExplode;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Explosion();
    }

    // Start is called before the first frame update
    void Start()
    {
        animExplode = GetComponentInChildren<Animator>();
        AIDestinationSetter dest = gameObject.AddComponent(typeof(AIDestinationSetter)) as AIDestinationSetter;
        dest.target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("Explosion", timeForExplode);
    }

    private void Explosion()
    {
        animExplode.SetTrigger("Collided");
        Destroy(gameObject, 0.26f);
    }
}
