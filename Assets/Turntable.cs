using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turntable : MonoBehaviour
{
    [SerializeField] float _speed = 30;

    [Header("Sine Y")]
    [SerializeField] float _frequency=1;
    [SerializeField] float _amplitude=1;
    Vector3 _basePose;

    private void Awake()
    {
        _basePose = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = _basePose + Vector3.up * Mathf.Sin(Time.time * _frequency) * _amplitude; 

        transform.Rotate(Vector3.up * _speed * Time.deltaTime,Space.World);
    }
}
