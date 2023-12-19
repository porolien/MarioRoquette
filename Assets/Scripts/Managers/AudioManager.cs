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
    // all : pitch random entre 0.5 et 0.7
    public void PlayMissile()
    {
        PlaySound(missileSound,1,1); // réduire volume
    }
    public void PlayExplosion()
    {
        PlaySound(explosionSound,1,1); // réduire volume
    }
    public void PlayJump()
    {
        sfxSource.pitch = -10;
        PlaySound(jumpSound,1,1);
        
    }
    public void PlayFootsteps()
    {
        PlaySound(footstepsSounds[Random.Range(0,5)],1,1); //suppr liste rdm ?
        //PlaySound(footstepSound); <- a tester avec le pitch / volume haut
    }
    public void PlayFall()
    {
        PlaySound(fallSound,1,1); // volume haut et pitch bas
    }
    public void PlayFlight()
    {
        PlaySound(flightSound,1,1); //ça marche pas connard
    }
    public void PlayCoin() // réduire volume(?)
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
