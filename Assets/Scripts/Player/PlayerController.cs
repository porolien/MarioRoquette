using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.VFX;

public class PlayerController : DynamicObject
{

    [Header("Physics")]
    public float GroundPlayerAcceleration = 160;
    public float AirPlayerAcceleration = 50;
    public float maxWalkSpeed = 15;
    public float GroundDamping = 50;
    public float AirDamping = 10;
    public float maxAirSpeed = 20;
    public float InitialJumpPower = 10;
    public float JumpThrustPower = 10;
    public float JumpTime = 0.5f;
    [SerializeField] float rocketJumpPower = 10;
    [SerializeField] float reculRoquette = 10;

    [SerializeField] AudioClip clip;
    public AudioSource audioSource;
    [SerializeField] GameObject prefabBalle;
    //Vector2 direction;

    [Header("Inputs")]
    public Vector2 MovementInput = new Vector2(0,0);
    public bool isHoldingJumpKey = false;
    public bool isHoldingSprintKey = false;

    public bool canShoot;
    public float cadence;

    VisualEffect walkVFX;

    // Start is called before the first frame update
    private void Awake()
    {
        cadence = 0.75f;
        SetUpPhysics();
        canShoot = true;
    }

    private void Start()
    {
        RocketManager.Instance.playerController = this;
        walkVFX = GetComponentInChildren<VisualEffect>();
    }

    private void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.R))
        {
            Velocity = new Vector2(1,1) * 30;
        }*/
        isHoldingJumpKey = Input.GetKey(KeyCode.Space);
        //AddForce(MovementInput * playerAcceleration * Vector2.right);

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

    /*public void OnJump(InputValue jump)
    {
        isHoldingJumpKey = jump.Get<float>()!=0;
    }

    public void OnStopJump(InputValue jump)
    {
        isHoldingJumpKey = false;
    }*/
    public void RocketShoot()
    {
        AudioManager.Instance.Playsound(clip);
        //audioSource.Play();
        GameObject newBalle = Instantiate(prefabBalle, transform.position, transform.rotation);
        Vector2 Direction = RocketManager.Instance._moveRocketLauncher.Cursor.position - transform.position;
        newBalle.GetComponent<RocketMove>().Sense = Direction;
        AddImpulse(-Direction * reculRoquette);

    }

    public void setWalkParticlesActive(bool newActive)
    {
        if(newActive)
        {
            walkVFX.Play();
        }
        else
        {
            walkVFX.Stop();
        }
        //walkVFX.Stop();
    }

    void Explosion(Vector2 Center)
    {
        Vector2 direcRocketJump = new Vector2(transform.position.x, transform.position.y) - Center;
        Vector2 n_DirecRocketJump = direcRocketJump.normalized;
        AddImpulse(n_DirecRocketJump / (direcRocketJump.magnitude + 1) * rocketJumpPower);
    }

    public void OnShoot()
    {
        //Debug.Log("su");
        if (canShoot)
        {
            RocketShoot();
            StartCoroutine(Delay());
        }
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
        if(collision.gameObject.tag == "Bloc")
        {
            if ((collision.transform.position.y - transform.position.y) > 0.8)
            {
                //Ouvrir la Box
            }
        }
    }

        IEnumerator Delay()
        {
            canShoot = false;
            yield return new WaitForSeconds(cadence);
            canShoot = true;

        }

    }
