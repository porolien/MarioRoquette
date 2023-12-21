using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class PowerUp : DynamicObject
{
    public GameObject PrefabRocket;
    private float vitesse = 100;
    private float vmax = 10;
    static int NmbrDePowerUpMax = 3;
    static int NmbreDePowerUpEnCours = 0;
    public GameObject infoText;

    private void Awake()
    {
        SetUpPhysics();
        NmbreDePowerUpEnCours = 0;
    }

    void LateUpdate()
    {
        UpdatePhysics();
       
    }
     void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * vitesse, GetComponent<Collider2D>().bounds.size.x / 2 + 0.1f, LayerMask.GetMask("Solid"));
        Debug.DrawRay(transform.position, Vector3.right * (GetComponent<Collider2D>().bounds.size.y / 2 + 0.1f), Color.red);
        if (hit) 
        {
            vitesse *= -1;
        }
        
        
        if(Mathf.Abs(Velocity.x)<vmax) AddForce(Vector2.right * vitesse);
        
    }
    protected virtual void PowerUpEffect()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        if (other.gameObject.tag == "Player")
        {
            AudioManager.Instance.PlayPowerUp();
            if(NmbreDePowerUpEnCours < NmbrDePowerUpMax)
            {
                NmbreDePowerUpEnCours++;
                Destroy(gameObject);
                PowerUpEffect();
            }
            else if (NmbreDePowerUpEnCours > NmbrDePowerUpMax)
            {
                Destroy(gameObject);
            }
          
        }

      
    }
}
