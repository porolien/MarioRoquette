using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    public void GoToPlay()
    {
        SceneManager.LoadScene("Tests_Nathan");
        print("Oui");
    }

    public void LeaveGame()
    {
        Application.Quit();
    }
}