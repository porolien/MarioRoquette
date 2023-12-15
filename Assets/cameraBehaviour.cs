using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraBehaviour : MonoBehaviour
{
    public GameObject TargetGameObject;
    public float smoothTime = 0.1f;
    Vector3 vel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = transform.position;
        target.x = TargetGameObject.transform.position.x;

        transform.position = Vector3.SmoothDamp(transform.position, target, ref vel, smoothTime);
    }
}
