using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerTexte;
    [SerializeField] TextMeshProUGUI bestTimerTexte;
    public float elapsedTime = 0;
    bool gameIsNotFinish;

    private void Start()
    {
            gameIsNotFinish = true;
            ScoreManager.Instance.timer = this;
            bestTimerTexte.text = (Mathf.Round(PlayerPrefs.GetFloat("Timer") * 100f) / 100f) + "";
        
    }
    void Update()
    {
        if (gameIsNotFinish)
        {
            elapsedTime += Time.deltaTime;
            timerTexte.text = Mathf.Round(elapsedTime * 100f) / 100f + "";
        }
    }

    public void StopTime()
    {
        gameIsNotFinish = false;
    }
    
}
