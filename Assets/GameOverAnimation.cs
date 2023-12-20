using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameOverAnimation : MonoBehaviour
{

    private static GameOverAnimation _instance = null;
    public static GameOverAnimation Instance => _instance;
    private void Awake()
    {
        //Singleton
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


    public void Play()
    {
        GetComponentInChildren<Animation>().Play();
    }
}
