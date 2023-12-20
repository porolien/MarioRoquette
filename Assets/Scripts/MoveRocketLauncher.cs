using DG.Tweening;
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
        RocketManager.Instance.playerController = FindObjectOfType<PlayerController>();
    }
    private void FixedUpdate()
    {

        //Move Cursor
        if (RocketManager.Instance!=null && RocketManager.Instance.playerController.isControllerMode)
        {
            transform.right = new Vector3( RocketManager.Instance.playerController.aimDirection.x, RocketManager.Instance.playerController.aimDirection.y, 0).normalized;
            if (UnityEngine.Cursor.visible)
            {
                UnityEngine.Cursor.visible = false;
            }
            //rocketLauncher.transform.up = new Vector3(RocketManager.Instance.playerController.aimDirection.x, RocketManager.Instance.playerController.aimDirection.y, 0).normalized; 
        }
        else
        {
            transform.right = (Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position)).normalized;
            if (!UnityEngine.Cursor.visible)
            {
                UnityEngine.Cursor.visible = true;
            }
            //rocketLauncher.transform.up = (Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position)).normalized;
        }
        Vector2 offset = RocketManager.Instance.playerController.transform.position - Cursor.transform.position;
        //RocketManager.Instance.playerController.transform.position - Cursor.transform.position
        
        rocketLauncher.transform.eulerAngles = Vector3.forward * (Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg);
        rocketLauncher.transform.Rotate(rocketLauncher.transform.rotation.x, rocketLauncher.transform.rotation.y, rocketLauncher.transform.rotation.z - 90);
        
        //transform.Translate(new Vector2(1, 0) * 5 * Time.deltaTime);

    }
}
