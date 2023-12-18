using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraBehaviour : MonoBehaviour
{
    public GameObject TargetGameObject;
    public float targetY;
    public float smoothTime = 0.1f;
    public float previsionDuJOueur = 1;
    Vector3 vel;
    // Start is called before the first frame update
    void Start()
    {
        targetY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = transform.position;
        target.x = TargetGameObject.transform.position.x + Mathf.Clamp( TargetGameObject.GetComponent<DynamicObject>().getVelocity().x,-8,8)* previsionDuJOueur;
        target.y = targetY;

        transform.position = Vector3.SmoothDamp(transform.position, target, ref vel, smoothTime);
    }
    void Explosion()
    {
        Debug.Log("OPTNSAMERE");
        ShakeManager.Instance.OnShake(0.25f, 1, 15, transform.GetChild(0));
    }
}
