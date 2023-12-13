using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{
     public GameObject prefabBalle;
     
     public void rocketShoot() 
     {
        GameObject newBalle = Instantiate(prefabBalle, transform.position, transform.rotation);
        newBalle.GetComponent<rocketMove>().Sense =  RocketManager.Instance._moveRocketLauncher.Cursor.position - transform.position;
       
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnShoot() 
    {
        Debug.Log("su");
        rocketShoot();
    }

    public void OnMove(InputValue Walk)
    {
        Debug.Log(Walk.Get<Vector2>());
    }


}
