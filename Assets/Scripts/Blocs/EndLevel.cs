using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Wow t'a finis t'est vraiment trop chaud mec");
            RocketMove.muultiplicateurScale = 1;
            RocketMove.RayonDeLexplosion = 3;
            RocketMove.multiplicateurDeLexplosion = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
            
        }
    }
}

