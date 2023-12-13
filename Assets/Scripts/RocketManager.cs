using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketManager : MonoBehaviour
{
    public MoveRocketLauncher _moveRocketLauncher;

    //Singleton
    private static RocketManager _instance = null;
    public static RocketManager Instance => _instance;
    //


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

    public void UseTheCursor(MoveRocketLauncher _theCursor)
    {
        
    }    
}

