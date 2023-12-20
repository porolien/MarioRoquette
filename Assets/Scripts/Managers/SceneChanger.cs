using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    public void GoToPlay()
    {
        SceneManager.LoadScene("Tests_Nathan");
        //print("Oui");
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void GoToCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void LeaveGame()
    {
        Application.Quit();
    }
}
