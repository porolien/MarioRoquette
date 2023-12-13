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
        //Ejecte le power up vers le haut
    }

    public void MysteryBlocIsDestroyed()
    {
        //Lancer le power up à l'endroit opposé à l'explosion
    }
}
