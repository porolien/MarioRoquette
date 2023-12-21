using Dan.Demo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    public LeaderboardShowcase leaderboardShowcase;
    public GameObject leaderBoardUI;
    public GameObject UIWhenBestTimer;
    public PlayerController playerController;

    private void Awake()
    {
        leaderboardShowcase=FindObjectOfType<LeaderboardShowcase>();
        //leaderBoardUI = GameObject.Find("LeaderBoard");
        //UIWhenBestTimer =GameObject.Find("UIWhenBestTimer");
        playerController =FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            AudioManager.Instance.PlayWin();
            Debug.Log("victoire");
            RocketMove.muultiplicateurScale = 1;
            RocketMove.RayonDeLexplosion = 3;
            RocketMove.multiplicateurDeLexplosion = 1;
            ScoreManager.Instance.timer.StopTime();
            
            if(PlayerPrefs.GetFloat("Timer" + SceneManager.GetActiveScene().name) > ScoreManager.Instance.SetBestTimer() || PlayerPrefs.GetFloat("Timer" + SceneManager.GetActiveScene().name) == 0)
            {
                PlayerPrefs.SetFloat("Timer" + SceneManager.GetActiveScene().name, Mathf.Round(ScoreManager.Instance.SetBestTimer() * 100f) / 100f );

                UIWhenBestTimer.SetActive(true);
                
            }
            
            
            playerController.playerInput.SwitchCurrentActionMap("UI");
            leaderBoardUI.SetActive(true);
            leaderboardShowcase._playerScore = (int)(Mathf.Round(ScoreManager.Instance.SetBestTimer() * 100f));
            leaderboardShowcase.AddPlayerScore();
            
        }
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

}

