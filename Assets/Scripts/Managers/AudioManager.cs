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
    [SerializeField] AudioClip missileSound;
    [SerializeField] AudioClip explosionSound;
    [SerializeField] AudioClip jumpSound;

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

    public void PlayMissile()
    {
        PlaySound(missileSound);
    }
    public void PlayExplosion()
    {
        PlaySound(explosionSound);
    }
    public void PlayJump()
    {
        PlaySound(jumpSound);
    }
    public void PlaySound(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    public void PlayMusic(AudioClip clip)
    {
        musicSource.PlayOneShot(clip);
    }
}