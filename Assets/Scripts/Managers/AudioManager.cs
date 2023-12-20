using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class AudioManager : MonoBehaviour
{
    //Singleton
    private static AudioManager _instance = null;
    public static AudioManager Instance => _instance;

    public AudioSource sourceMusique ;
    [SerializeField] AudioClip missileSound;
    [SerializeField] AudioClip explosionSound;
    [SerializeField] AudioClip jumpSound;
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

        sourceMusique = GameObject.Find("Music Source").GetComponent<AudioSource>();
    }
    // all : pitch random entre 0.5 et 0.7
    public void PlayMissile()
    {
        PlaySound(missileSound,Random.Range(0.8f,1), 0.8f); // réduire volume
    }
    public void PlayExplosion()
    {
        PlaySound(explosionSound, Random.Range(0.8f, 1), 0.8f) ; // réduire volume
    }
    public void PlayJump()
    {
        PlaySound(jumpSound, Random.Range(0.8f, 1));
    }
    public void PlayFootsteps()
    {
        PlaySound(footstepSound, Random.Range(0.8f, 1)); //suppr liste rdm ?
        //PlaySound(footstepSound); <- a tester avec le pitch / volume haut
    }
    public void PlayFall()
    {
        PlaySound(fallSound, Random.Range(0.8f, 1)); // volume haut et pitch bas
    }
    public void PlayFlight()
    {
        PlaySound(flightSound, Random.Range(0.8f, 1)); //ça marche pas connard
    }
    public void PlayCoin() // réduire volume(?)
    {
        PlaySound(coinSound, Random.Range(0.8f, 1));
    }
    public void PlayPowerUp()
    {
        PlaySound(powerUpSound, Random.Range(0.8f, 1));
    }
    public void PlayBounce()
    {
        PlaySound(bounceSound, Random.Range(0.8f, 1));
    }
    public void PlayWin()
    {
        PlaySound(winSound);
    }
    public void PlayDeath()
    {
        PlaySound(deathSound);
    }
    public void PlaySound(AudioClip clip, float pitch = 1, float volume = 1)
    {
        AudioSource source = gameObject.AddComponent<AudioSource>();
        source.volume = volume;
        source.pitch = pitch;
        source.PlayOneShot(clip);
        Destroy(source, 2);
    }
    public void PlayMusic()
    {
        sourceMusique.Play();
    }
    public void StopMusic()
    {
        sourceMusique.Stop();
    }

    // Tous les sons sont trouvés sur pixabay.
    // musique par Karl Casey @ White Bat Audio
}
