using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class TargetScript : MonoBehaviour
{
    bool wait = false;
    private AIPath path;
    private AIDestinationSetter destination;
    [SerializeField] private Transform[] roomPoints;


    [SerializeField] private GameObject rocketPrefab;
    [SerializeField] private Transform[] rocketSpawnPos;
    private Vector3 rocketSpawn;
    private Quaternion rocketRotation;
    private Vector3 scale; // scale of player (where they're looking at)

    [SerializeField] private SwitchCam InTrigger;

    private Animator anim;


    void Start()
    {
        destination = GetComponent<AIDestinationSetter>();
        path = GetComponent<AIPath>();
        anim = GetComponentInChildren<Animator>();
        scale = GetComponentInChildren<EnemyGFX>().Scale;
    }


    void Update()
    {
        if (InTrigger.Inside)
        {
            if (path.reachedDestination && !wait)
            {
                Invoke("NewDestination", 2f);
                anim.SetTrigger("Shoot");
                Invoke("Shoot", 0.5f);
                Invoke("Shoot", 0.75f);

                wait = true;
            }
        }
        
    }

    private void Shoot()
    {
        scale = GetComponentInChildren<EnemyGFX>().Scale;

        if (scale.x > 0)
        {
            rocketRotation = Quaternion.Euler(0, 0, -90);
            rocketSpawn = rocketSpawnPos[1].position;
        }
        else
        {
            rocketRotation = Quaternion.Euler(0, 0, 90);
            rocketSpawn = rocketSpawnPos[0].position;
        }

        Instantiate(rocketPrefab, rocketSpawn, rocketRotation, null);

    }

    private void NewDestination()
    {
        destination.target = roomPoints[Random.Range(0, 4)];
        Invoke("SetFalse", 1f);
    }

    private void SetFalse()
    {
        wait = false;
    }

}
