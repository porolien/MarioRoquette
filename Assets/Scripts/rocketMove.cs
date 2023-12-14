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
    void Start()
    {
        Destroy(gameObject, DureeDeVie);
        TailleDeLaRocket();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Sense*Vitesse*Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        string playerTag = "Player";
        switch (other.gameObject.tag)
        {
            case "RocketRadar":
                break;

        }
        if(other.gameObject.tag != "Player") 
        {
            Debug.Log("Ceci est une explosion");
            Explose();
        }
        
    }

    void Explose() 
    {

        Collider2D[] ObjetsTouches = Physics2D.OverlapCircleAll(transform.position, RayonDeLexplosion);
        foreach(Collider2D ObjetTouche in ObjetsTouches)
        {
            Debug.Log("Nom de l'objet touché" + ObjetTouche.gameObject.name);
            ObjetTouche.gameObject.SendMessage("Explosion",(Vector2) transform.position, SendMessageOptions.DontRequireReceiver);
            Debug.DrawRay(ObjetTouche.gameObject.transform.position, Vector3.up);

        }

        Destroy(gameObject);
    }


    public void TailleDeLaRocket()
    {
        transform.localScale += TailleRocket;


    }
}

//Etape 1: faire overlap cicle pr avoir la liste des gameobjects que l'explosion touche
//Etape 2: Iterer dans cette Liste (foreach) pr chaque element de la liste sendmessage fdp 
