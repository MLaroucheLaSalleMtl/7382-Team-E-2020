using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FollowMouse : MonoBehaviour
{
    string controlType;

    Vector2 lookPos = new Vector2();
    [SerializeField] private Transform map;
    [SerializeField] private SpriteRenderer player;

    Ray2D ray;


    public void OnLook(InputAction.CallbackContext context){
        controlType = context.control.device.name;


        if (controlType == "XInputControllerWindows")
        {
            this.transform.localPosition = context.ReadValue<Vector2>();
        }
        else
        {
            lookPos = context.ReadValue<Vector2>();
            this.transform.position =
            Camera.main.ScreenToWorldPoint(new Vector3(lookPos.x, lookPos.y, map.position.z - Camera.main.transform.position.z));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        /* Teacher's code for reference ===================================================
        Ray ray = Camera.main.ScreenPointToRay(mPos);                                    ||
        Vector3 pos = ray.GetPoint (map.position.z - Camera.main.transform.position.z);  ||
        this.transform.position = pos;                                                   ||
        =================================================================================*/



        ray = new Ray2D(player.transform.position, this.transform.localPosition);

        //Debug.DrawRay(player.transform.position, this.transform.localPosition, Color.blue);

        GameObject.FindWithTag("NearCur").transform.position = 
            new Vector2(ray.GetPoint(0.15f).x, ray.GetPoint(0.15f).y + 0.05f);


        if (!player.GetComponent<CharacterMovement>().Run ||
            player.GetComponent<CharacterMovement>().Run && 
            player.GetComponent<CharInteracts>().Count > 0)
        {
            if (this.transform.localPosition.x < 0)
            {
                player.flipX = true;
            }
            else
            {
                player.flipX = false;
            }
        }
        else
        {
            player.flipX = (player.GetComponent<CharacterMovement>().Move.x < 0);
        }

    }

}
