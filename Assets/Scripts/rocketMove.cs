using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.XR;

public class RocketMove : MonoBehaviour
{
    public Vector2 Sense;
    public float Vitesse;
    public float DureeDeVie;
    public Vector3 TailleRocket;
    public float RayonDeLexplosion;
    Collider2D col;
    [SerializeField] AudioSource audioSource;
    [SerializeField] private GameObject explosionVfxPrefab;
    ContactFilter2D contactFilter;
    public float multiplicateurDeLexplosion = 1;

    void Start()
    {
        //audioSource=GetComponent<AudioSource>();
        RocketManager.Instance.rocketMove = this;
        col = GetComponent<Collider2D>();
        contactFilter.layerMask = LayerMask.GetMask("Solid") & LayerMask.GetMask("Ennemis");

        Destroy(gameObject, DureeDeVie);
        TailleDeLaRocket();
    }

    // Update is called once per frame
    void Update()
    {
        

        List<RaycastHit2D> results = new List<RaycastHit2D>();
        if (col.Cast(Sense, contactFilter, results, Sense.magnitude * Vitesse * Time.deltaTime, true) > 0)
        {
            Debug.Log(results[0].collider.name);
            string playerTag = "Player";
            switch (results[0].collider.gameObject.tag)
            {
                case "RocketRadar":
                    break;

            }
            if (results[0].collider.gameObject.tag != "Player")
            {
                Debug.Log("Ceci est une explosion");
                Explose(results[0]);

            }
        }
        
            transform.Translate(Sense * Vitesse * Time.deltaTime);
        
    }


    void Explose(RaycastHit2D collision)
    {
        //send message to hit objects
        Collider2D[] ObjetsTouches = Physics2D.OverlapCircleAll(transform.position, RayonDeLexplosion);
        foreach (Collider2D ObjetTouche in ObjetsTouches)
        {
            Debug.Log("Nom de l'objet touché" + ObjetTouche.gameObject.name);
            ObjetTouche.gameObject.SendMessage("Explosion",/*(Vector2) transform.position*/collision.point, SendMessageOptions.DontRequireReceiver);
            Debug.DrawRay(ObjetTouche.gameObject.transform.position, Vector3.up);

        }
        //vfx
        GameObject explosionVfx = GameObject.Instantiate(explosionVfxPrefab, transform.position + (Vector3)collision.normal*0.5f, Quaternion.identity);
       // explosionVfx.transform.localScale *= multiplicateurDeLexplosion;
        Destroy(explosionVfx, 2);
        //sfx
        //audioSource.Play();
        Destroy(gameObject);
        //sfx

    }


    public void TailleDeLaRocket()
    {
        transform.localScale += TailleRocket;


    }
}


//Etape 1: faire overlap cicle pr avoir la liste des gameobjects que l'explosion touche
//Etape 2: Iterer dans cette Liste (foreach) pr chaque element de la liste sendmessage fdp 
