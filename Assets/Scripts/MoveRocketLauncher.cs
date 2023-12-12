using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRocketLauncher : MonoBehaviour
{
    Transform Cursor;

    private void Start()
    {
        Cursor = transform.GetChild(0);
    }
    private void FixedUpdate()
    {
        //Move Cursor
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.right = (new Vector3(mouse.x, mouse.y, 0) - transform.position).normalized;
    }
}
