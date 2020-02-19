using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharInteracts : MonoBehaviour
{
    [SerializeField] Transform cross;
    [SerializeField] Transform gun;
    [SerializeField] float fireRate = 0.4f;

    private float count = 0;
    private bool canShoot = true;
    private bool justFired = false;
    private bool fire = false;

    public float Count { get => count; }

    public void OnShoot(InputAction.CallbackContext context)
    {
        Shoot();
    }

    private void Shoot()
    {
        if (!justFired && this.GetComponent<CharacterMovement>().IsGrounded)
        {
            RaycastHit2D hit = Physics2D.Raycast(gun.transform.position, cross.localPosition, 25f);
            Debug.DrawLine(gun.transform.position, hit.point, Color.blue, 0.05f);
            justFired = true;
        }

        // Debug.Log(hit.collider.gameObject.tag);
    }

    // Start is called before the first frame update
    void Start()
    {
        
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
}
