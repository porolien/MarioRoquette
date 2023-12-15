using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlayer : MonoBehaviour
{
    public GameObject Joueur;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Bah t'est mort pas ouf quoi");
        Destroy(Joueur);
    }
}
