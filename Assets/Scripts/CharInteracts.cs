using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
//added library
using UnityEngine.UI;

public class CharInteracts : MonoBehaviour
{
    [SerializeField] private Transform cross;
    [SerializeField] private Transform gun;
    [SerializeField] private LineRenderer line;
    [SerializeField] float fireRate = 0.4f;

    [SerializeField] private int rocketDamage = 15;
    [SerializeField] private float crawlerDamage = 10f;

    //Added ammo counter vairables
    [SerializeField] Text ammoCounter;
    int ammoMax = 20;
    int ammoCurrent;

    //Sound effect variables
    public AudioSource shotSnd;
    public AudioSource reloadSnd;

    private Vector3[] linepos = new Vector3[2];
    private float count = 0;
    private bool canShoot = true;
    private bool justFired = false;
    private bool fire = false;
    bool isReloading;

    public bool interactive;

    public float Count { get => count; }

    int layerMask = 1 << 10;

    public void OnShoot(InputAction.CallbackContext context)
    {
        Shoot();
    }


    private void Shoot()
    {
        if (!justFired && !(ammoCurrent == 0)/*&& this.GetComponent<CharacterMovement>().IsGrounded*/)
        {
            RaycastHit2D hit = Physics2D.Raycast(gun.transform.position, cross.localPosition, 25f, layerMask);
            shotSnd.Play();
            line.gameObject.SetActive(true);

            linepos[0] = gun.transform.position;
            linepos[1] = hit.point;

            line.SetPositions(linepos);

            if (hit.collider.tag == "Enemy" )
            {
                if (hit.collider.GetComponent<CrawlerNPC>())
                {
                    hit.collider.GetComponent<CrawlerNPC>().TakeDamage(crawlerDamage);
                }
                else if (hit.collider.GetComponent<BossInteractive>())
                {
                    hit.collider.GetComponent<BossInteractive>().TakeDamage(rocketDamage);
                }
            }
            if (hit.collider.tag == "Rocket")
            {
                Destroy(hit.collider.gameObject);
            }

            Invoke("HideLine", 0.05f);

            // Debug.DrawLine(gun.transform.position, hit.point, Color.blue, 0.05f);

            justFired = true;
            ammoCurrent -= 1;
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

        //Ammo initialization
        ammoCurrent = ammoMax;
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
        if (isReloading && !(ammoCurrent == ammoMax))
        {
            Reload();
            Debug.Log("Reload!");
        }
        ammoCounter.text = "Ammo : " + ammoCurrent +"/" + ammoMax;

    }


    public void OnReload(InputAction.CallbackContext context)
    {
        isReloading = context.performed;
    }
    public void Reload()
    {
        ammoCurrent = ammoMax;
        reloadSnd.Play();
    }


}
