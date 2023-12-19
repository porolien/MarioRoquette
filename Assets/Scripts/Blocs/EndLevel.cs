using Dan.Demo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    public LeaderboardShowcase leaderboardShowcase;
    public GameObject leaderBoardUI;
    public PlayerController playerController;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            RocketMove.muultiplicateurScale = 1;
            RocketMove.RayonDeLexplosion = 3;
            RocketMove.multiplicateurDeLexplosion = 1;
            ScoreManager.Instance.timer.StopTime();
            
            if(PlayerPrefs.GetFloat("Timer") > ScoreManager.Instance.SetBestTimer() || PlayerPrefs.GetFloat("Timer") == 0)
            {
                PlayerPrefs.SetFloat("Timer", Mathf.Round(ScoreManager.Instance.SetBestTimer() * 100f) / 100f );
                playerController.playerInput.SwitchCurrentActionMap("UI");
                leaderBoardUI.SetActive(true);
                leaderboardShowcase._playerScore = (int)(Mathf.Round(PlayerPrefs.GetFloat("Timer") * 100f));
                leaderboardShowcase.AddPlayerScore();
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
            }
            
        }
    }

}

