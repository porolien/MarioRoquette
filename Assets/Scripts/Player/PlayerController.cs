using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
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
    public float coyoteTime = 0.2f;
    public float footstepsSeparation = 0.5f;
    [SerializeField] float rocketJumpPower = 10;
    [SerializeField] float reculRoquette = 10;

    [SerializeField] AudioClip missileSound;
    public AudioClip jumpSound;
    [SerializeField] GameObject prefabBalle;
    public IBasePlayerState _currentState;
    public IdleState _idleState;
    public PlayerAnim playerAnim;
    float rota;
    public Vector2 aimDirection;
    public PlayerInput playerInput;
    public GameObject RocketLauncher;
    //Vector2 direction;

    [Header("Inputs")]
    public Vector2 MovementInput = new Vector2(0,0);
    public bool isHoldingJumpKey = false;
    public bool isHoldingSprintKey = false;

    public bool isControllerMode;

    public bool canShoot;
    public float cadence;

    VisualEffect walkVFX;

    // Start is called before the first frame update
    private void Awake()
    {
        cadence = 0.75f;
        SetUpPhysics();
        canShoot = true;
        playerInput = GetComponent<PlayerInput>();
        RocketManager.Instance.playerController = this;
        walkVFX = transform.Find("vfx_smoke").GetComponent<VisualEffect>();
        playerInput.SwitchCurrentActionMap("Player");
    }

    private void Start()
    {
        //PlayerPrefs.DeleteAll();
        
    }

    private void Update()
    {
        //enable particle trail when going at high speed
        GetComponent<TrailRenderer>().emitting= Velocity.sqrMagnitude > 35 * 35;

        //block hitting 
        
        RaycastHit2D[] hit = new RaycastHit2D[1];
        Debug.DrawRay(transform.position, Vector2.up * (col.bounds.size.y/2 + 0.1f+Velocity.y*Time.deltaTime), Color.red);
        if (Velocity.y > 0 && Physics2D.CircleCast(transform.position, col.bounds.size.x/2-0.1f, Vector2.up,contactFilter, hit, col.bounds.size.y / 2 + 0.1f + Velocity.y * Time.deltaTime) >0)//transform.position, Vector2.up,  , out hit, LayerMask.GetMask("Solid")))
        {
            if(hit[0].collider.gameObject.GetComponentInChildren<Blocs>()) hit[0].collider.gameObject.GetComponentInChildren<Blocs>().BlocHitted();
        }
            
    }

    public void OnMove(InputValue move)
    {
        MovementInput = move.Get<Vector2>();
        
        switch (MovementInput.x)
        {
            case -1:
                rota = 180;
                break;
            case 1:
                rota = 0 ;
                break;
        }
        transform.rotation = Quaternion.Euler(transform.rotation.x, rota, transform.rotation.z);
        //direction = playerAcceleration * move.Get<Vector2>();
    }

    public void OnJump(InputValue value)
    {
        //Debug.Log(value.Get<float>());
        if(value.Get<float>() == 1) 
        {
            isHoldingJumpKey = true;
        }
        else
        {
            isHoldingJumpKey = false;
        }
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
        AudioManager.Instance.PlaySound(missileSound);
        GameObject newBalle = Instantiate(prefabBalle, transform.position, transform.rotation);
        Vector2 Direction = RocketManager.Instance._moveRocketLauncher.Cursor.position - transform.position;
        transform.Find("MoveCursor/vfx_muzzleFlash").GetComponent<VisualEffect>().Play();
        if (rota == 180)
        {
            Direction = new Vector2 (-RocketManager.Instance._moveRocketLauncher.Cursor.position.x + transform.position.x, transform.position.y - RocketManager.Instance._moveRocketLauncher.Cursor.position.y  );
            AddImpulse(Direction * reculRoquette);
            Direction = new Vector2(-RocketManager.Instance._moveRocketLauncher.Cursor.position.x + transform.position.x, -transform.position.y + RocketManager.Instance._moveRocketLauncher.Cursor.position.y);
        }
        else
        {
            AddImpulse(-Direction * reculRoquette);
        }
        
        
        newBalle.GetComponent<RocketMove>().Sense = Direction;
        
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

    public void OnReset()
    {
        StartCoroutine( Retry());
    }

    public void OnMoveCursorController(InputValue value)
    {
        Debug.Log(value.Get<Vector2>());
        aimDirection = value.Get<Vector2>();
        isControllerMode = true;
    }

    public void OnMoveCursorMouse(InputValue value)
    {
        /*Debug.Log(value.Get<Vector2>());
        aimDirection = value.Get<Vector2>();*/
        isControllerMode = false;
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
        /*if(collision.gameObject.tag == "Bloc" && _currentState == _idleState)
        {
            if ((collision.transform.position.y - transform.position.y) > 0.8 && (Mathf.Abs(collision.transform.position.x - transform.position.x) <= 0.9))
            {
                if(collision.gameObject.GetComponent<Blocs>() != null)
                {
                    collision.gameObject.GetComponent<Blocs>().BlocHitted();
                }
            }
        }*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("cameraCheckpoint"))
        {
            Camera.main.transform.parent.gameObject.GetComponent<cameraBehaviour>().targetY = collision.gameObject.transform.position.y;
        }
    }
    IEnumerator Delay()
        {
            canShoot = false;
            yield return new WaitForSeconds(cadence);
            canShoot = true;

        }
    public void PlayASound()
    {
        AudioManager.Instance.PlayFootsteps();
    }

    public IEnumerator Retry()
    {
        GameOverAnimation.Instance.Play();
        yield return new WaitForSeconds(0.38f);
        RocketMove.muultiplicateurScale = 1;
        RocketMove.RayonDeLexplosion = 3;
        RocketMove.multiplicateurDeLexplosion = 1;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }
}
