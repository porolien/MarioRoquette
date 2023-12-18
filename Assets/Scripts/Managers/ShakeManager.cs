using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEditor;

public class ShakeManager : MonoBehaviour
{
    private static ShakeManager _instance = null;
    public static ShakeManager Instance => _instance;

    private void Awake()
    {
        //Singleton
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            _instance = this;
        }

    }
    public void OnShake(float duration, float strength, int vibrato, Transform ObjectToShake)
    {
        ObjectToShake.DOShakePosition(duration, strength, vibrato);
        ObjectToShake.DOShakeRotation(duration, strength, vibrato);
    }
}
