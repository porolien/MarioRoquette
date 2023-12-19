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
    [SerializeField] List<AudioClip> footstepsSounds;
    [SerializeField] AudioClip footstepSound;

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
        sfxSource.pitch = -10;
        PlaySound(jumpSound);
        
    }
    public void PlayFootsteps()
    {
        PlaySound(footstepsSounds[Random.Range(0, 5)]);
        //PlaySound(footstepSound);
    }
    public void PlaySound(AudioClip clip)
    {
        sfxSource.pitch = Random.Range(0.8f,1);
        Debug.Log(sfxSource.pitch);
        sfxSource.PlayOneShot(clip);
    }

    public void PlayMusic(AudioClip clip)
    {
        musicSource.PlayOneShot(clip);
    }
}
