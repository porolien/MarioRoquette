using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : DynamicObject
{
    public float playerAcceleration = 160;
    public float jumpPower = 30;
    Vector2 direction;
    // Start is called before the first frame update
    private void Awake()
    {
        SetUpPhysics();
    }

    private void FixedUpdate()
    {
        //AddForce(Input.GetAxis("Horizontal")*playerAcceleration*Vector2.right);
        AddForce(direction);
    }

    public void OnMove(InputValue move)
    {
        direction = playerAcceleration * move.Get<Vector2>();
    }

    public void OnJump(InputValue jump)
    {
        Debug.Log(IsGrounded());
        if (IsGrounded())
        {
            AddImpulse(Vector3.up * jumpPower);
            Debug.Log("ça saute");
        }
    }


    // Update is called once per frame
    void LateUpdate()
    {
        UpdatePhysics();
    }
}
