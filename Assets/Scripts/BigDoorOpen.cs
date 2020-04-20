using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigDoorOpen : MonoBehaviour
{

    public Animator animator;
    public GameObject player;
    private GameManager instance;
    [SerializeField] private GameObject Intrigger;
    [SerializeField] private GameObject Collider;
    private bool lockTriggered = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        instance = GameManager.instance;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player" && instance.AmountOfEnemies <= 0)
        {
            animator.SetBool("Bigopen", true);
            Collider.SetActive(false);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Intrigger.GetComponent<SwitchCam>().Inside && !lockTriggered)
        {
            animator.SetTrigger("LockDoor");
            animator.SetBool("Bigopen", false);
            Collider.SetActive(true);
            lockTriggered = true;
        }
    }
}
