using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysteryBlocs : Blocs
{
    
    public PowerUp powerUp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MysteryBlocIsTouched()
    {
        PowerUp newPowerUp = Instantiate(powerUp);
        newPowerUp.GetComponent<DynamicObject>().AddImpulse(new Vector3(0, 10, 0));


    }

    public void MysteryBlocIsDestroyed()
    {
        PowerUp newPowerUp = Instantiate(powerUp);
        //Lancer le power up à l'endroit opposé à l'explosion
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Wow un power UP");
            MysteryBlocIsTouched();
            Destroy(this);
            
        }

        if (other.gameObject.tag == "Rocket")
        {
            Debug.Log("Wow t'a fais valser le powerUP");
            MysteryBlocIsDestroyed();
            Destroy(transform.parent.gameObject);
        }

    }
}
