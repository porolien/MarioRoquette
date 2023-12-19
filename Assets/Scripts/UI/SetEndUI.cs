using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetEndUI : MonoBehaviour
{
    public GameObject leaderboardUI;
    public TextMeshProUGUI PlayerScore;

    public void SetTheUI()
    {
        leaderboardUI.SetActive(true);
        PlayerScore.text = "You need " + PlayerPrefs.GetFloat("Timer") + " to finish this level";
    }
}
