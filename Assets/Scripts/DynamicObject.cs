using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class DynamicObject : MonoBehaviour
{
    public Vector2 Velocity = Vector2.zero;
    private Vector2 Acceleration = Vector2.zero;
    [SerializeField] public float gravityScale = 102;
    [SerializeField] private float bounciness = 0;
    [SerializeField] private float mass = 1;
    [SerializeField] public float Damping = 1f;
    private Vector2 totalForce = Vector2.zero;
    private Rigidbody2D rb;
    private Collider2D col;

    ContactFilter2D contactFilter;

    public bool isGrounded = false;

    public Vector2 getAcceleration() { return Acceleration; }
    public Vector2 getVelocity() { return Velocity; }

    public void AddForce(Vector2 ForceToAdd)
    {
        totalForce+=ForceToAdd / mass;
    }

    public void AddImpulse(Vector2 ForceToAdd)
    {
        totalForce += ForceToAdd / mass / Time.deltaTime;
    }

    public void SetUpPhysics()
    {
        rb = GetComponent<Rigidbody2D>();
        col=GetComponent<Collider2D>();
        contactFilter.layerMask = LayerMask.GetMask("Solid");
    }
    public void UpdatePhysics()
    {
        isGrounded = CheckForGround();
        //gravity
        if (!isGrounded)
        {
            //print(IsGrounded());
            AddForce(Vector2.down * gravityScale);
        }

        //apply forces
        Velocity += totalForce * Time.deltaTime;
        Acceleration = -totalForce;

        //damping

        float vel = Mathf.Max(Mathf.Abs(Velocity.x) -  Time.deltaTime*Damping, 0);
        vel *= Mathf.Sign(Velocity.x);

        Velocity.x = vel;


        checkForCollisions();

        //apply velocity
        rb.position += Velocity * Time.deltaTime;

        //reset force
        totalForce = Vector3.zero;
    }
    bool CheckForGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, GetComponent<Collider2D>().bounds.size.y/2+0.1f, LayerMask.GetMask("Solid"));
        Debug.DrawRay(transform.position, Vector3.down * (GetComponent<Collider2D>().bounds.size.y / 2 + 0.1f),Color.red);
        //Debug.Log(hit.collider.name);
        //return  hit ;
        return hit;//rb.velocity.y == 0;

    }
    void checkForCollisions()
    {
        List<RaycastHit2D> results = new List<RaycastHit2D>();
        if (col.Cast(Velocity,contactFilter,results,Velocity.magnitude*Time.deltaTime,true) > 0)
        {
            foreach(RaycastHit2D hit in results )
            {
                if (Vector3.Dot (hit.point-(Vector2)transform.position,Velocity)>0)
                {
                    //snap object to hit surface
                    rb.position += Velocity * Time.deltaTime * hit.fraction;
                    //Velocity *= hit.fraction;
                    Debug.DrawRay(rb.position, Vector3.up, Color.red, 5);
                    Velocity = (Vector2)Vector3.ProjectOnPlane(Velocity, hit.normal) + hit.normal * bounciness;
                }
                
            }
        }


    }

   /* private void Awake()
    {
        SetUpPhysics();
        
    }

    void LateUpdate()
    {
        UpdatePhysics();
    }*/
}