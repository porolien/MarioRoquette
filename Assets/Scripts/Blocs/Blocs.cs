using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocs : MonoBehaviour
{
    public bool breakable;

    void Explosion(Vector2 Center)
    {
        if (breakable)
        {
        Destroy(gameObject);
        Debug.Log("Ta mere nathan");

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
    }
}
