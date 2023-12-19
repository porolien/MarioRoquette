using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

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
    //[SerializeField] AudioClip footstepSound;
    [SerializeField] AudioClip fallSound;
    [SerializeField] AudioClip flightSound;
    [SerializeField] AudioClip coinSound;

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
        PlaySound(missileSound,1,1);
    }
    public void PlayExplosion()
    {
        PlaySound(explosionSound,1,1);
    }
    public void PlayJump()
    {
        sfxSource.pitch = -10;
        PlaySound(jumpSound,1,1);
        
    }
    public void PlayFootsteps()
    {
        PlaySound(footstepsSounds[Random.Range(0,5)],1,1);
        //PlaySound(footstepSound);<- a tester avec le pitch
    }
    public void PlayFall()
    {
        PlaySound(fallSound,1,1);
    }
    public void PlayFlight()
    {
        PlaySound(flightSound,1,1);
    }
    public void PlayCoin()
    {
        PlaySound(coinSound,1,1);
    }
    public void PlaySound(AudioClip clip, float volume, float pitch)
    {
        /*if (clip == fallSound)
        {
            sfxSource.pitch = Random.Range(0.5f,0.7f);
        }
        else if (clip == coinSound)
        {
            sfxSource.pitch = 1;
        }
        else
        {
            sfxSource.pitch = Random.Range(0.8f,1);
        }*/

        gameObject.AddComponent<AudioSource>();
        AudioSource source = GetComponent<AudioSource>();
        source.volume = volume;
        source.pitch = pitch;
        source.PlayOneShot(clip);
        Destroy(GetComponent<AudioSource>(),2);
        //sfxSource.PlayOneShot(clip);
    }

    public void PlayMusic(AudioClip clip)
    {
        musicSource.PlayOneShot(clip);
    }
}
