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
            Debug.Log(PlayerPrefs.GetFloat("Timer"));
            Debug.Log(ScoreManager.Instance.SetBestTimer());
            if(PlayerPrefs.GetFloat("Timer") > ScoreManager.Instance.SetBestTimer() || PlayerPrefs.GetFloat("Timer") == 0)
            {
                PlayerPrefs.SetFloat("Timer", Mathf.Round(ScoreManager.Instance.SetBestTimer() * 100f) / 100f );
                setEndUI.SetTheUI();
            }
            
        }
    }

}

