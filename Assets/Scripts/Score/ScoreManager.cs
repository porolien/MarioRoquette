using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    //Singleton
    private static ScoreManager _instance = null;
    public static ScoreManager Instance => _instance;
    //

    public Timer timer = null;
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
        }
        //
    }

    public float SetBestTimer()
    {
        return timer.elapsedTime;
    }
}
