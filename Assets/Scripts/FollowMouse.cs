using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FollowMouse : MonoBehaviour
{
    Vector2 mPos = new Vector2();
    [SerializeField] private Transform map;
    [SerializeField] private SpriteRenderer player;
    
    public void OnLook(InputAction.CallbackContext context){
        mPos = context.ReadValue<Vector2>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        /* Teacher's code for reference ===================================================
        Ray ray = Camera.main.ScreenPointToRay(mPos);                                    ||
        Vector3 pos = ray.GetPoint (map.position.z - Camera.main.transform.position.z);  ||
        this.transform.position = pos;                                                   ||
        =================================================================================*/
        this.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(mPos.x, mPos.y, map.position.z - Camera.main.transform.position.z));


        if (!player.GetComponent<CharacterMovement>().Run)
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

    }

}
