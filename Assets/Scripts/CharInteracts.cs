using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharInteracts : MonoBehaviour
{
    [SerializeField] private Transform cross;
    [SerializeField] private Transform gun;
    [SerializeField] private LineRenderer line;
    [SerializeField] float fireRate = 0.4f;

    private Vector3[] linepos = new Vector3[2];
    private float count = 0;
    private bool canShoot = true;
    private bool justFired = false;
    private bool fire = false;

    public bool interactive;

    public float Count { get => count; }

    public void OnShoot(InputAction.CallbackContext context)
    {
        Shoot();
    }


    private void Shoot()
    {
        if (!justFired /*&& this.GetComponent<CharacterMovement>().IsGrounded*/)
        {
            RaycastHit2D hit = Physics2D.Raycast(gun.transform.position, cross.localPosition, 25f);

            line.gameObject.SetActive(true);

            linepos[0] = gun.transform.position;
            linepos[1] = hit.point;

            line.SetPositions(linepos);

            if (hit.collider.tag == "Enemy")
            {
                hit.collider.GetComponent<CrawlerNPC>().TakeDamage(20);
            }

            Invoke("HideLine", 0.05f);

            // Debug.DrawLine(gun.transform.position, hit.point, Color.blue, 0.05f);

            justFired = true;            
        }

        // Debug.Log(hit.collider.gameObject.tag);
    }

    private void HideLine()
    {
        line.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        HideLine();
    }

    // Update is called once per frame
    void Update()
    {
        if (justFired && count < fireRate)
        {
            count += Time.deltaTime;
        }
        else if (count >= fireRate)
        {
            count = 0;
            justFired = false;
        }
    }

    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if(collision.tag == "textLog")
    //     {
    //         if(collision.GetComponent<summaryScript>())
    //         {
    //         }
    //     }

    // }


}
