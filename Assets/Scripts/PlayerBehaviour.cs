using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{
    public float vitesse;
    float puissanceSprint = 2;
    public float jumpForce = 10;
    Rigidbody rb;
    Vector2 velocity;
    public float acceleration = 60;
    public float decceleration = 1;
    //[SerializeField] float fallgravityScale = 15;
     public GameObject prefabBalle;
     
     public void rocketShoot() 
     {
        GameObject newBalle = Instantiate(prefabBalle, transform.position, transform.rotation);
        newBalle.GetComponent<rocketMove>().Sense =  RocketManager.Instance._moveRocketLauncher.Cursor.position - transform.position;
       
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        velocity += new Vector2(vitesse, 0) * Time.deltaTime * acceleration;
        velocity.x = velocity.x * Mathf.Pow(0.5f, Time.deltaTime * decceleration); 
        transform.Translate(velocity*Time.deltaTime);
        Debug.Log("su");
        rocketShoot();
    }

    
    public void OnMove(InputValue Walk)
    {
        vitesse = Walk.Get<Vector2>().x;
        Debug.Log("bouge");
    }
    public void OnJump(InputValue Jump)
    {
        if (IsGrounded())
        {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if(IsFalling())
        {
           // rb.gravityscale = fallgravityScale;
        }
        Debug.Log("OPTN");

    }

    public void OnSprint(InputValue sprint)
    {
        acceleration *= puissanceSprint;
    }
    
    public bool IsGrounded()
    {
        return rb.velocity.y == 0;
    }
    public bool IsFalling()
    {
        return rb.velocity.y < 0;
    }
    /*    public float gravityScale = 1.0f;
 
    // Global Gravity doesn't appear in the inspector. Modify it here in the code
    // (or via scripting) to define a different default gravity for all objects.
 
    public static float globalGravity = -9.81f;
 
    Rigidbody m_rb;
 
    void OnEnable ()
        {
        m_rb = GetComponent<Rigidbody>();
        m_rb.useGravity = false;
        }
 
    void FixedUpdate ()
        {
        Vector3 gravity = globalGravity * gravityScale * Vector3.up;
        m_rb.AddForce(gravity, ForceMode.Acceleration);
        }
    }*/
}
