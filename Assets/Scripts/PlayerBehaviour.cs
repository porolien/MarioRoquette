using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{
    public float vitesse;
    Vector2 velocity;
    public float vitesseMax = 10;
    public float acceleration = 60;
    public float decceleration = 1;
    private void FixedUpdate()
    {
        velocity += new Vector2(vitesse, 0) * Time.deltaTime * acceleration;
        velocity.x = velocity.x * Mathf.Pow(0.5f, Time.deltaTime * decceleration); 
        transform.Translate(velocity*Time.deltaTime);
    }
    public void OnMove(InputValue Walk)
    {
        vitesse = Walk.Get<Vector2>().x;
        Debug.Log("bouge");
    }

    public void OnJump(InputValue Jump)
    {
        Debug.Log("OPTN");
    }

    public void OnSprint(InputValue sprint)
    {

    }
}
