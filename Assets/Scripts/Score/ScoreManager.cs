using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    //Singleton
    private static ScoreManager _instance = null;
    public static ScoreManager Instance => _instance;
    //

    public int score {  get ; private set;}  = 0;
    public Timer timer = null;

    [Header("Display")]
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text HighScoreText;
    private void Awake()
    {
        //Singleton
        if (_instance != null && _instance != this)
        {
            _instance.score = 0;
            Destroy(this.gameObject);
            return;
        }
        else
        {
            _instance = this;
            //DontDestroyOnLoad(gameObject);
        }

        updateScoreDisplay();
    }

    public void IncreaseScore(int toAdd)
    {
        score += toAdd;
        if(PlayerPrefs.GetInt("HighScore"+SceneManager.GetActiveScene().name) < score)
        {
            PlayerPrefs.SetInt("HighScore" + SceneManager.GetActiveScene().name, score) ;
        }

        
        updateScoreDisplay();
    }

    void updateScoreDisplay()
    {
        scoreText.text = "Destruction Score: " + score.ToString();
        if (HighScoreText != null) HighScoreText.text = "Highest: " + PlayerPrefs.GetInt("HighScore" + SceneManager.GetActiveScene().name).ToString();
    }

    public float SetBestTimer()
    {
        return timer.getTime();
    }
}
