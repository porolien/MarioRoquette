
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
    GameObject player;
    [SerializeField] bool physicsEnabled = false;
    [SerializeField]
    public void Awake()
    {
        SetUpPhysics();
        player = FindObjectOfType<PlayerController>().gameObject;
        nmbreDePiece = 0;
        //CoinTexte = GameObject.Find("ShowCoin").GetComponent<TMP_Text>();
    }

    void LateUpdate()
    {
        if (physicsEnabled) UpdatePhysics();
    }

    private void Update()
    {
        Vector2 offset = player.transform.position - transform.position;
        if (Vector2.SqrMagnitude(offset) < magnetDistance * magnetDistance && !Physics2D.Raycast(transform.position, offset, magnetDistance, LayerMask.GetMask("solid")))
        {
            magnetDistance = 100;
            transform.position = Vector2.SmoothDamp(transform.position, player.transform.position, ref Velocity, 0.07f, maxVelocity);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !isDead)
        {
            StartCoroutine(Die());
        }
    }

    void OnSpawnedByQuestionBlock()
    {
        physicsEnabled = true;
    }

    void Explosion(Vector2 Center)
    {
        physicsEnabled = true;
        AddImpulse(((Vector2)transform.position-Center).normalized*20);
    }

    IEnumerator Die()
    {
        isDead = true;
        AudioManager.Instance.PlayCoin();
        nmbreDePiece++;
        //CoinTexte.text = nmbreDePiece.ToString();
        GetComponentInChildren<Animator>().StopPlayback();
        transform.localScale *= 1.6f;

        GameObject Popup = GameObject.Instantiate(scorePopupPrefab, transform.position + Vector3.forward * -1, Quaternion.identity);
        Popup.GetComponent<scorePopup>().init(200, Color.white);
        Popup.transform.localScale *= 2;

        yield return new WaitForSeconds(0.05f);
        //Debug.Log("Tu as " + nmbreDePiece + " Coins");
        Destroy(gameObject);
    }
}


