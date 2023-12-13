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
   
    void Start()
    {
        Destroy(gameObject, DureeDeVie);
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
}
