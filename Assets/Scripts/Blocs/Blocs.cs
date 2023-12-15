using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocs : MonoBehaviour
{
    public bool breakable;
    public bool canExplosed;

    void Explosion(Vector2 Center)
    {
        if (canExplosed)
        {
        Destroy(gameObject);
        Debug.Log("Ta mere nathan");

        }

    }

    public virtual void BlocHitted()
    {
        if(!breakable) 
        { 
            //grossir le bloc et le faire monter un ptit peu, puis le rétrecir et le remettre à sa place
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
