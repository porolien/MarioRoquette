using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : DynamicObject
{

    [Header("Physics")]
    public float playerAcceleration = 160;
    public float jumpPower = 30;
    public float maxWalkSpeed = 15;
    public float GroundDamping = 50;
    [SerializeField] float rocketJumpPower = 10;


    [SerializeField] GameObject prefabBalle;
    //Vector2 direction;

    [Header("Inputs")]
    public Vector2 MovementInput = new Vector2(0,0);
    public bool isHoldingJumpKey = false;


    // Start is called before the first frame update
    private void Awake()
    {
        SetUpPhysics();
    }

    private void Update()
    {
        AddForce(MovementInput * playerAcceleration * Vector2.right);

        /*//AddForce(Input.GetAxis("Horizontal")*playerAcceleration*Vector2.right);
        AddForce(direction);
        //print(move.Get<Vector2>());
        if (MovementInput.sqrMagnitude > 0.1f )
        {
            Damping = 0;
            if (Mathf.Abs(Velocity.x) > 10)
            {
                Damping = playerAcceleration;
            }
        }
        else
        {
            if (isGrounded)
            {
                Damping = 30;
                
            }
            else
            {


                Damping = gravityScale;
            }


        }


        print(direction);*/
    }

    public void OnMove(InputValue move)
    {
        MovementInput = move.Get<Vector2>();
        //direction = playerAcceleration * move.Get<Vector2>();
    }

    public void OnJump(InputValue jump)
    {
        isHoldingJumpKey = jump.Get<bool>();
        //Debug.Log(IsGrounded());
        /*if (IsGrounded)
        {
            AddImpulse(Vector3.up * jumpPower);
            //Debug.Log("�a saute");
        }*/
    }
    public void RocketShoot()
    {
        GameObject newBalle = Instantiate(prefabBalle, transform.position, transform.rotation);
        newBalle.GetComponent<RocketMove>().Sense = RocketManager.Instance._moveRocketLauncher.Cursor.position - transform.position;

    }

    void Explosion(Vector2 Center)
    {
        Vector2 direcRocketJump = new Vector2(transform.position.x, transform.position.y) - Center;
        Vector2 n_DirecRocketJump = direcRocketJump.normalized;
        n_DirecRocketJump.x *= 3;
        AddImpulse(n_DirecRocketJump / (direcRocketJump.magnitude + 1) * rocketJumpPower);
    }

    public void OnShoot()
    {
        //Debug.Log("su");
        RocketShoot();
    }


    // Update is called once per frame
    void LateUpdate()
    {
        UpdatePhysics();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ennemy")
        {
            if ((transform.position.y - collision.transform.position.y) > 0.8)
            {
                Destroy(collision.gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
