using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class scorePopup : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        float s = Random.Range(0.8f, 1.2f)*0.5f;
        GetComponentInChildren<Animator>().speed = s;
        Destroy(gameObject,0.4f/s);
        transform.localScale *= 0.15f;
    }

    // Update is called once per frame
    public void init(int score, Color color )
    {
        TMP_Text text = GetComponentInChildren<TMP_Text>();
        
        //text.outlineColor = color;
        text.text = "+" + score.ToString();

        //scoreManager.score += score; 
    }
}
