using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicNeverSTOP : MonoBehaviour
{
    private static MusicNeverSTOP instance;
    // Start is called before the first frame update
    void Awake()
    {
        if(instance != null)
        {
            Debug.Log("dest");
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        transform.SetParent(null);
        DontDestroyOnLoad(gameObject);
    }

}
