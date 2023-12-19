using Dan.Demo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    public LeaderboardShowcase leaderboardShowcase;
    public GameObject leaderBoardUI;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            RocketMove.muultiplicateurScale = 1;
            RocketMove.RayonDeLexplosion = 3;
            RocketMove.multiplicateurDeLexplosion = 1;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
            Debug.Log(PlayerPrefs.GetFloat("Timer"));
            Debug.Log(ScoreManager.Instance.SetBestTimer());
            if(PlayerPrefs.GetFloat("Timer" + SceneManager.GetActiveScene().name) > ScoreManager.Instance.SetBestTimer() || PlayerPrefs.GetFloat("Timer" + SceneManager.GetActiveScene().name) == 0)
            {
                PlayerPrefs.SetFloat("Timer", Mathf.Round(ScoreManager.Instance.SetBestTimer() * 100f) / 100f );
                
            }
            leaderBoardUI.SetActive(true);
            leaderboardShowcase._playerScore = (int)(Mathf.Round(PlayerPrefs.GetFloat("Timer") * 100f)) ;
            leaderboardShowcase.AddPlayerScore();
        }
    }

}

