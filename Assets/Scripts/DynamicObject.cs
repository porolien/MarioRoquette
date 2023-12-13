using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DynamicObject : MonoBehaviour
{
    public Vector2 Velocity = Vector2.zero;
    private Vector2 Acceleration = Vector2.zero;
    [SerializeField] private float gravityScale = 102;
    [SerializeField] private float bounciness = 0;
    [SerializeField] private float mass = 1;
    [SerializeField] private float Damping = 2.5f;
    private Vector2 totalForce = Vector2.zero;
    private Rigidbody2D rb;
    private Collider2D col;
    ContactFilter2D contactFilter;

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
        //gravity
        if(!IsGrounded())
        {
            AddForce(Vector2.down * gravityScale);
        }

        //apply forces
        Velocity += totalForce * Time.deltaTime;
        Acceleration = -totalForce;

        Velocity.x*=Mathf.Pow(0.01f, Time.deltaTime* Damping);

        checkForCollisions();

        //apply velocity
        rb.position += Velocity * Time.deltaTime;

        //reset force
        totalForce = Vector3.zero;
    }
    public bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 0.6f, LayerMask.GetMask("Solid"));
        //Debug.Log(hit.collider.name);
        return  hit ;    

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
