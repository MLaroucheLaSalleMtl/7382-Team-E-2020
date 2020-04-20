using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCam : MonoBehaviour
{
    [SerializeField] private Animator camAnim;
    [SerializeField] private GameObject bossHpBar;
    private bool inside = false;

    public bool Inside { get => inside; set => inside = value; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            camAnim.SetBool("InBossRoom", this.gameObject.name == "InTrigger");
            Inside = (this.gameObject.name == "InTrigger");
            
        }
    }

    private void Start()
    {
        bossHpBar.SetActive(Inside);
    }

    private void Update()
    {
        if (inside)
        {
            bossHpBar.SetActive(Inside);

        }
    }
}
