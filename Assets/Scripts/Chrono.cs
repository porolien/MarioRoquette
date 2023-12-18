using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Chrono : MonoBehaviour
{
    static float chrono;
    [SerializeField]
    public TMP_Text Texte;

    private void Awake()
    {
        
    }

    public void Update()
    {
        GetComponent<TMP_Text>().text = ((int)Time.time).ToString();        
        //TMP_Text chrono;
    }


}
