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
    [SerializeField] AudioClip missileSound;
    [SerializeField] AudioClip explosionSound;
    [SerializeField] AudioClip jumpSound;
    //[SerializeField] List<AudioClip> footstepsSounds;
    [SerializeField] AudioClip footstepSound;
    [SerializeField] AudioClip fallSound;
    [SerializeField] AudioClip flightSound;
    [SerializeField] AudioClip coinSound;
    [SerializeField] AudioClip powerUpSound;
    [SerializeField] AudioClip bounceSound;
    [SerializeField] AudioClip winSound;
    [SerializeField] AudioClip deathSound;


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
        PlaySound(missileSound); // réduire volume
    }
    public void PlayExplosion()
    {
        PlaySound(explosionSound); // réduire volume
    }
    public void PlayJump()
    {
        PlaySound(jumpSound);
    }
    public void PlayFootsteps()
    {
        PlaySound(footstepSound); //suppr liste rdm ?
        //PlaySound(footstepSound); <- a tester avec le pitch / volume haut
    }
    public void PlayFall()
    {
        PlaySound(fallSound); // volume haut et pitch bas
    }
    public void PlayFlight()
    {
        PlaySound(flightSound); //ça marche pas connard
    }
    public void PlayCoin() // réduire volume(?)
    {
        PlaySound(coinSound);
    }
    public void PlayPowerUp()
    {
        PlaySound(powerUpSound);
    }
    public void PlayBounce()
    {
        PlaySound(bounceSound);
    }
    public void PlayWin()
    {
        PlaySound(winSound);
    }
    public void PlayDeath()
    {
        PlaySound(deathSound);
    }
    public void PlaySound(AudioClip clip, float volume=1, float pitch=1)
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

        AudioSource source = gameObject.AddComponent<AudioSource>();
        source.volume = volume;
        source.pitch = pitch;
        source.PlayOneShot(clip);
        Destroy(source, 2);
    }

    // Tous les sons sont trouvés sur pixabay.
    // musique par Karl Casey @ White Bat Audio
}
