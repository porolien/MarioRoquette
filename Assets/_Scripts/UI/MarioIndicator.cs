using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioIndicator : MonoBehaviour
{
    GameObject player;
    bool isShow;
    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject obj in FindObjectsOfType<GameObject>())
        {
            if (obj.tag == "Player")
            {
                player = obj;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isShow) 
        {
            if (player.transform.position.y >= 20)
            {
                ShowOrUnShowIndicator(true);
            }
        }
        else
        {
            if (player.transform.position.y <= 17)
            {
                ShowOrUnShowIndicator(false);
            }
        }
    }

    void ShowOrUnShowIndicator(bool showPicture)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(showPicture);
        }
    }
}
