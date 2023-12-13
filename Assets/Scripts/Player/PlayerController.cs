using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : DynamicObject
{
    public float playerAcceleration = 160;
    public float jumpPower = 30;
    public float rocketJumpPower = 10;
    public GameObject prefabBalle;
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
            Debug.Log("�a saute");
        }
    }
    public void rocketShoot()
    {
        GameObject newBalle = Instantiate(prefabBalle, transform.position, transform.rotation);
        newBalle.GetComponent<rocketMove>().Sense = RocketManager.Instance._moveRocketLauncher.Cursor.position - transform.position;

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
        Debug.Log("su");
        rocketShoot();
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
