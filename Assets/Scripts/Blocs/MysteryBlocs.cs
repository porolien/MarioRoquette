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
        PowerUp newPowerUp = Instantiate(powerUp,transform.position+Vector3.up,Quaternion.identity);
        newPowerUp.GetComponent<DynamicObject>().AddImpulse(new Vector3(0, 8, 0));


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
            
            //Destroy(transform.parent.gameObject);
        }

    }

    void Explosion(Vector2 source)
    {
        Debug.Log("Wow t'a fais valser le powerUP");
        PowerUp newPowerUp = Instantiate(powerUp, transform.position + Vector3.up, Quaternion.identity);
        Vector2 recul = (Vector2)transform.position - source;
        recul = recul.normalized*20;
        newPowerUp.GetComponent<DynamicObject>().AddImpulse(recul);

        Destroy(transform.parent.gameObject);
    }
}
