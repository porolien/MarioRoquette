using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerTexte;
    [SerializeField] TextMeshProUGUI bestTimerTexte;
    bool gameIsNotFinish;
    float StartTime = 0;
    private void Start()
    {
        gameIsNotFinish = true;
        ScoreManager.Instance.timer = this;
        bestTimerTexte.text = ("Best: " + Mathf.Round(PlayerPrefs.GetFloat("Timer") * 100f) / 100f);
        StartTime = Time.time;
    }
    void Update()
    {
        if (gameIsNotFinish)
        {
            timerTexte.text = "Current Time: " + Mathf.Round(getTime() * 100f) / 100f + "";
        }
    }

    public float getTime()
    {
        return Time.time - StartTime;
    }
    public void StopTime()
    {
        gameIsNotFinish = false;
    }
    
}
