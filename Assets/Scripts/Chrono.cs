using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerTexte;
    float elapsedTime = 0;
    

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        timerTexte.text = Mathf.Round(elapsedTime * 100f) / 100f + "";
        /*if (elapsedTime > 0)
        {
            monTIme();
        }
        else
        {
            elapsedTime = 0;
            timerTexte.text = elapsedTime.ToString();
        }*/
    }

    public void monTIme()
    {
      
        /*int minute = (int)(elapsedTime / 60);
        int seconds = (int)(elapsedTime % 60);
        
        if (seconds < 10)
        {
            timerTexte.text = (minute.ToString() + ":0" + seconds.ToString());
        }
        else
        {
            timerTexte.text = (minute.ToString() + ":" + seconds.ToString());
        }

        timerTexte.maxVisibleCharacters = 4;*/
    }
}
