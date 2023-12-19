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
    public float elapsedTime = 0;

    private void Start()
    {
        ScoreManager.Instance.timer = this;
        bestTimerTexte.text = "Best: " + (Mathf.Round(PlayerPrefs.GetFloat("Timer" + SceneManager.GetActiveScene().name) * 100f) / 100f ).ToString() + "";
    }
    void Update()
    {
        elapsedTime += Time.deltaTime;
        timerTexte.text = "Current Time: "+  Mathf.Round(elapsedTime * 100f) / 100f ;
    }

    
}
