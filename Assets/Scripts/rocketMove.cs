using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.XR;

public class rocketMove : MonoBehaviour
{
    public Vector3 Sense;
    public float Vitesse; 
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Sense*Vitesse);
    }
}
