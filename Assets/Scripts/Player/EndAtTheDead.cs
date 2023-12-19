using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndAtTheDead : MonoBehaviour
{
    public void NewLevel()
    {
        RocketMove.muultiplicateurScale = 1;
        RocketMove.RayonDeLexplosion = 3;
        RocketMove.multiplicateurDeLexplosion = 1;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }
}
