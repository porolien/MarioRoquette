using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    SetEndUI setEndUI;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Wow t'a finis t'est vraiment trop chaud mec");
            RocketMove.muultiplicateurScale = 1;
            RocketMove.RayonDeLexplosion = 3;
            RocketMove.multiplicateurDeLexplosion = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
            Debug.Log(PlayerPrefs.GetFloat("Timer" + SceneManager.GetActiveScene().name));
            Debug.Log(ScoreManager.Instance.SetBestTimer());
            if(PlayerPrefs.GetFloat("Timer" + SceneManager.GetActiveScene().name) > ScoreManager.Instance.SetBestTimer() || PlayerPrefs.GetFloat("Timer" + SceneManager.GetActiveScene().name) == 0)
            {
                PlayerPrefs.SetFloat("Timer" + SceneManager.GetActiveScene().name, Mathf.Round(ScoreManager.Instance.SetBestTimer() * 100f) / 100f );
                setEndUI.SetTheUI();
            }
            
        }
    }

}

