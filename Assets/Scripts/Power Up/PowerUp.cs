using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class PowerUp : DynamicObject
{
    public GameObject PrefabRocket;



    private void Awake()
    {
        SetUpPhysics();
    }

    void LateUpdate()
    {
        UpdatePhysics();
    }

    protected virtual void PowerUpEffect()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        if (other.gameObject.tag == "Player")
        {
            
            Destroy(gameObject);
            PowerUpEffect();
        }
    }
}
