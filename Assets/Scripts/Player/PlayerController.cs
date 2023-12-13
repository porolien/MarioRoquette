using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : DynamicObject
{
    public float playerAcceleration = 100;
    public float jumpPower;
    // Start is called before the first frame update
    private void Awake()
    {
        SetUpPhysics();
    }

    private void Update()
    {
        AddForce(Input.GetAxis("Horizontal")*playerAcceleration*Vector2.right);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("ta mère");
            AddInpulse(Vector3.up * jumpPower);
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        UpdatePhysics();
    }
}
