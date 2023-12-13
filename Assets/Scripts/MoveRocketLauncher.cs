using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRocketLauncher : MonoBehaviour
{
    public Transform Cursor;

    private void Start()
    {
        Cursor = transform.GetChild(0);
        RocketManager.Instance._moveRocketLauncher = this;
    }
    private void FixedUpdate()
    {
        //Move Cursor
        transform.right = (Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position)).normalized;
        //transform.Translate(new Vector2(1, 0) * 5 * Time.deltaTime);

    }
}
