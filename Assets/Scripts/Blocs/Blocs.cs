using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Blocs : MonoBehaviour
{
    public bool breakable;
    public bool canExplosed;
    [SerializeField] GameObject breakVFXPrefab;

    void Explosion(Vector2 Center)
    {
        if (canExplosed)
        {
            GameObject explosionVfx = GameObject.Instantiate(breakVFXPrefab, transform.position , Quaternion.identity);
            explosionVfx.GetComponent<VisualEffect>().SetVector3("AdditionalVelocity", (Vector3)(((Vector2)transform.position-Center).normalized*10));
            Destroy(explosionVfx, 2);
            Destroy(transform.parent.gameObject);
            Debug.Log("Ta mere nathan");

        }

    }

    public virtual void BlocHitted()
    {
        if(!breakable) 
        { 
            //grossir le bloc et le faire monter un ptit peu, puis le rétrecir et le remettre à sa place
            //puis le détruire?
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
