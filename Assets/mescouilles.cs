using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class mescouilles : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.Find("Sound Manager")!=null)
        {
            Destroy(GameObject.Find("Sound Manager"));
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
