using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRocketLauncher : MonoBehaviour
{
    public Transform Cursor;
    public GameObject rocketLauncher;

    private void Start()
    {
        Cursor = transform.GetChild(0);
        RocketManager.Instance._moveRocketLauncher = this;
    }
    private void FixedUpdate()
    {
        //Move Cursor
        if (RocketManager.Instance.playerController.isControllerMode)
        {
            transform.right = new Vector3( RocketManager.Instance.playerController.aimDirection.x, RocketManager.Instance.playerController.aimDirection.y, 0).normalized;
            //rocketLauncher.transform.up = new Vector3(RocketManager.Instance.playerController.aimDirection.x, RocketManager.Instance.playerController.aimDirection.y, 0).normalized; 
        }
        else
        {
            transform.right = (Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position)).normalized;
            //rocketLauncher.transform.up = (Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position)).normalized;
        }

        rocketLauncher.transform.up = RocketManager.Instance.playerController.transform.position - Cursor.transform.position;    
        //transform.Translate(new Vector2(1, 0) * 5 * Time.deltaTime);

    }
}
