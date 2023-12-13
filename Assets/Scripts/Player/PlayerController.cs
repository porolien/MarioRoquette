using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : DynamicObject
{
    public float playerAcceleration = 160;
    public float jumpPower = 30;
    // Start is called before the first frame update
    private void Awake()
    {
        SetUpPhysics();
    }

    private void Update()
    {
        AddForce(Input.GetAxis("Horizontal")*playerAcceleration*Vector2.right);
    }
    /*public void OnMove(InputValue move)
    {
        AddForce(playerAcceleration * Vector2.right);
    }*/

    public void OnJump(InputValue jump)
    {
        AddImpulse(Vector3.up * jumpPower);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        UpdatePhysics();
    }

}
