using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.XR;

public class rocketMove : MonoBehaviour
{
    public Vector2 Sense;
    public float Vitesse;
    public float DureeDeVie;
    public Vector3 TailleRocket;
    void Start()
    {
        Destroy(gameObject, DureeDeVie);
        TailleDeLaRocket();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Sense*Vitesse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag != "Player") 
        {
        Destroy(gameObject);
        }
            
        
    }


    public void TailleDeLaRocket()
    {
        transform.localScale += TailleRocket;


    }
}
