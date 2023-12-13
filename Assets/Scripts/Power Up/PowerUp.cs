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

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("T'a graille le powerUP FDP");
            Destroy(gameObject);
        }
    }
}
