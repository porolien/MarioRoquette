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
    public float maxVelocity = 40;
    private Vector2 totalForce = Vector2.zero;
    private Rigidbody2D rb;
    public Collider2D col;

    protected ContactFilter2D contactFilter;

    public bool isGrounded = false;

    public Vector2 getAcceleration() { return Acceleration; }
    public Vector2 getVelocity() { return Velocity; }

    public void AddForce(Vector2 ForceToAdd)
    {
        Velocity += ForceToAdd * Time.deltaTime;
        //totalForce+=ForceToAdd / mass;
    }

    public void AddImpulse(Vector2 ForceToAdd)
    {
        Velocity += ForceToAdd;
        //totalForce += ForceToAdd / mass / Time.deltaTime;
    }

    public void SetUpPhysics()
    {
        rb = GetComponent<Rigidbody2D>();
        col=GetComponent<Collider2D>();
        contactFilter.layerMask = LayerMask.GetMask("Solid");
        contactFilter.useLayerMask = true;
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
        
        Velocity = Vector2.ClampMagnitude(Velocity, maxVelocity);
        rb.position += Velocity* Time.deltaTime;

        //reset force
        totalForce = Vector3.zero;
    }
    bool CheckForGround()
    {
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, GetComponent<Collider2D>().bounds.size.y/2+0.1f, LayerMask.GetMask("Solid"));
        RaycastHit2D[] hits = new RaycastHit2D[1];
        int i = Physics2D.CircleCast(transform.position, col.bounds.size.x / 2, Vector2.down, contactFilter, hits, col.bounds.size.y / 2 + 0.1f  );
        Debug.DrawRay(transform.position, Vector3.down * (GetComponent<Collider2D>().bounds.size.y / 2 + 0.1f),Color.red);
        //Debug.Log(hit.collider.name);
        //return  hit ;
        return i>0;//rb.velocity.y == 0;

    }

    public bool checkForSideCollisions(float rightMagnitude)
    {
        List<RaycastHit2D> results = new List<RaycastHit2D>();

        return col.Cast(Vector3.right, contactFilter, results, rightMagnitude, true) > 0;
    }

    void checkForCollisions()
    {
        List<RaycastHit2D> results = new List<RaycastHit2D>();
        for(int i = 0; i < 3; i++)
        {
            if (col.Cast(Velocity, contactFilter, results, Velocity.magnitude * Time.deltaTime, true) > 0)
            {
                foreach (RaycastHit2D hit in results)
                {
                    if (Vector3.Dot(hit.point - (Vector2)transform.position, Velocity) > 0)
                    {
                        //snap object to hit surface
                        rb.position += Velocity * Time.deltaTime * hit.fraction;
                        //Velocity *= hit.fraction;
                        Debug.DrawRay(rb.position, Vector3.up, Color.red, 5);
                        Velocity = (Vector2)Vector3.ProjectOnPlane(Velocity, hit.normal) + hit.normal * bounciness;
                    }

                }
            }
            else
            {
                break;
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
