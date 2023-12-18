
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
    bool isDead = false;
    public void Awake()
    {
        nmbreDePiece = 0;
        CoinTexte = GameObject.Find("ShowCoin").GetComponent<TMP_Text>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !isDead)
        {
            StartCoroutine(Die());
        }
    }

    IEnumerator Die()
    {
        isDead = true;
        nmbreDePiece++;
        CoinTexte.text = nmbreDePiece.ToString();
        GetComponentInChildren<Animator>().StopPlayback();
        transform.localScale *= 1.6f ;
        yield return new WaitForSeconds(0.2f);
        Debug.Log("Tu as " + nmbreDePiece + " Coins");
        Destroy(gameObject);
    }
}


