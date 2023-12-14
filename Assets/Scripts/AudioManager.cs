using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //Singleton
    private static AudioManager _instance = null;
    public static AudioManager Instance => _instance;
    //
    [SerializeField] AudioSource musicSource, sfxSource;
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
    public void Playsound(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
}
