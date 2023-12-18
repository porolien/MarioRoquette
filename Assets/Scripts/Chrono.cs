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
        if (elapsedTime > 0)
        {
            monTIme();
        }
        else
        {
            elapsedTime = 0;
            timerTexte.text = elapsedTime.ToString();
        }
    }

    public void monTIme()
    {
        elapsedTime += Time.deltaTime;
        int minute = (int)(elapsedTime / 60);
        int seconds = (int)(elapsedTime % 60);

        if (seconds < 10)
        {
            timerTexte.text = (minute.ToString() + ":0" + seconds.ToString());
        }
        else
        {
            timerTexte.text = (minute.ToString() + ":" + seconds.ToString());
        }

        timerTexte.maxVisibleCharacters = 4;
    }
}
