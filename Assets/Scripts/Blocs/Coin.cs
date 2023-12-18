<<<<<<< Updated upstream
using Microsoft.Win32.SafeHandles;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Coin : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coinText;
    private TMP_Text CoinTexte;
    static float nmbreDePiece;

    public void Awake()
    {
        nmbreDePiece = 0;
        CoinTexte = GameObject.Find("ShowCoin" ).GetComponent<TMP_Text>();
    }
    private void Update()
    {
       CoinTexte.text  = nmbreDePiece.ToString() ;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            nmbreDePiece++;
            Debug.Log("Tu as " +nmbreDePiece +" Coins");  
            Destroy(gameObject);
            
        }
    }
}


