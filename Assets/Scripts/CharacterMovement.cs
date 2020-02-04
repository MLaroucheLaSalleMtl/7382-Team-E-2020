using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D rigid;
    private Vector2 move = new Vector2();
    private Vector3 zeroVelocity = Vector3.zero;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float smoothing = 0.1f;

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 pos = new Vector3();
        pos.x = move.x * speed;
        pos.y = move.y * speed;
        rigid.velocity = Vector3.SmoothDamp(rigid.velocity, pos, ref zeroVelocity, smoothing);
    }
}
