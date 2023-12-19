
using Microsoft.Win32.SafeHandles;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Coin : DynamicObject
{
    [SerializeField] TextMeshProUGUI coinText;
    [SerializeField] GameObject scorePopupPrefab;
    //private TMP_Text CoinTexte;
    static float nmbreDePiece;
    bool isDead = false;

    [SerializeField] float magnetDistance = 3;
    [SerializeField] float magnetStrength = 20;
    GameObject player;

    [SerializeField]
    public void Awake()
    {
        SetUpPhysics();
        player =FindObjectOfType<PlayerController>().gameObject;
        nmbreDePiece = 0;
        //CoinTexte = GameObject.Find("ShowCoin").GetComponent<TMP_Text>();
    }

    void LateUpdate()
    {
        UpdatePhysics();
    }

    private void Update()
    {
        Vector2 offset = player.transform.position - transform.position;
        if (Vector2.SqrMagnitude(offset)<magnetDistance*magnetDistance)
        {
            AddForce(offset.normalized*magnetStrength);
        }
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
        //CoinTexte.text = nmbreDePiece.ToString();
        GetComponentInChildren<Animator>().StopPlayback();
        transform.localScale *= 1.6f ;

        GameObject Popup = GameObject.Instantiate(scorePopupPrefab, transform.position+Vector3.forward*-1, Quaternion.identity);
        Popup.GetComponent<scorePopup>().init(200, Color.white);
        Popup.transform.localScale *= 2;

        yield return new WaitForSeconds(0.2f);
        Debug.Log("Tu as " + nmbreDePiece + " Coins");
        Destroy(gameObject);
    }
}


