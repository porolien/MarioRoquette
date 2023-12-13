using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : Ennemies
{
    private Vector2 direction;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector2(-1, 0);
        speed = 5;
    }

    private void FixedUpdate()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void MakeAnEscape()
    {

    }
}
