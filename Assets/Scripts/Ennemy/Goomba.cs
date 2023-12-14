using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Goomba : Ennemies
{
    private Vector2 direction;
    public float speed;

    private void Start()
    {
        direction = new Vector2(-1, 0);
        speed = 5;
    }
    private void FixedUpdate()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void ChangeDirection()
    {
        direction.x *= -1;
    }
}
