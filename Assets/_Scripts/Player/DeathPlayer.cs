using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathPlayer : MonoBehaviour
{
    public GameObject Joueur;
    string playerTag = "Player";
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Bah t'est mort pas ouf quoi");
            var pm = other.GetComponent<PlayerStateMachine>();
            if (pm.currentState != pm.dieState)
            {
                pm.Transition(pm.dieState);
            }
            
           /* Destroy(Joueur);
            RocketMove.muultiplicateurScale = 1;
            RocketMove.RayonDeLexplosion = 3;
            RocketMove.multiplicateurDeLexplosion = 1;
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);*/
            
        } 
    }
}
