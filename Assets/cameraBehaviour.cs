using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraBehaviour : MonoBehaviour
{
    public GameObject TargetGameObject;
    public float smoothTime = 0.1f;
    public float previsionDuJOueur = 1;
    Vector3 vel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = transform.position;
        target.x = TargetGameObject.transform.position.x + TargetGameObject.GetComponent<DynamicObject>().getVelocity().x* previsionDuJOueur;

        transform.position = Vector3.SmoothDamp(transform.position, target, ref vel, smoothTime);
    }
    void Explosion()
    {
        Debug.Log("OPTNSAMERE");
        ShakeManager.Instance.OnShake(0.5f, 3, 10, transform);
    }
}
