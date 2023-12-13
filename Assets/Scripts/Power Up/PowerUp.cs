using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class PowerUp : DynamicObject
{
    public GameObject PrefabRocket;


    public void ShootSpeed()
    {
        FindObjectOfType<rocketMove>().Vitesse *= 2;
    }

    private void Awake()
    {
        SetUpPhysics();
    }

    void LateUpdate()
    {
        UpdatePhysics();
    }
    // Start is called before the first frame update
    void Start()
    {
        ShootSpeed();
    }

    // Update is called once per frame
    void Update()
    {

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
