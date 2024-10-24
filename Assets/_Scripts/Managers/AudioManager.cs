using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.VFX;

public enum Sounds
{

}

public class AudioManager : MonoBehaviour
{
    /// <summary>
    /// the size of the AudioPool
    /// </summary>
    [SerializeField] int _poolSize;

    /// <summary>
    /// prefab with an audiosource on it
    /// </summary>
    [SerializeField] AudioSource _SFXObject;

    //singleton
    private static AudioManager instance = null;
    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = new GameObject("Audio Manager");
                instance = go.AddComponent<AudioManager>();
            }
            return instance;
        }
    }
    private void Awake()
    {
        instance = this;
    }

    public Queue<AudioSource> AudioPool = new Queue<AudioSource>();

    [SerializeField] AudioClip[][] _clips;

    private void Start()
    {
        for (int i = 0; i < _poolSize; i++)
        {
            AudioSource source = Instantiate(_SFXObject);
            source.gameObject.SetActive(false);
            AudioPool.Enqueue(source);
        }
    }

    /// <summary>
    /// sors de la pool/queue une audiosource et active son gameObject
    /// </summary>
    /// <returns></returns>
    AudioSource UseFromPool()
    {
        AudioSource currentSource = AudioPool.Dequeue();
        currentSource.gameObject.SetActive(true);
        return currentSource;
    }

    /// <summary>
    /// renvoie l'audioSource dans la pool et désactive son gameObject
    /// </summary>
    /// <param name="source"></param>
    void BackToPool(AudioSource source)
    {
        source.gameObject.SetActive(false);
        AudioPool.Enqueue(source);
    }

    public void PlaySFXClip(Sounds choosenSound, float volume = 1f, float pitch = 1f)
    {
        if (_clips[(int)choosenSound].Length == 0) // cas si l'array n'a pas été remplie correctement
        {
            print("y'a pas de sons là");
            return;
        }

        AudioClip audioClip = _clips[(int)choosenSound][Random.Range(0, _clips[(int)choosenSound].Length)];

        AudioSource audioSource = UseFromPool();

        audioSource.clip = audioClip; // assigne le clip random à l'auriosource
        audioSource.volume = volume; // assigne le volume à l'audiosource
        audioSource.pitch = pitch; // assigne le pitch aà l'audiosource
        audioSource.spatialBlend = 0; // désactive la spatialisation

        audioSource.Play(); // joue le son

        float clipLength = audioSource.clip.length; // détermine la longueur du son

        StartCoroutine(HandleSoundEnd(audioSource, clipLength));
    }

    public void PlaySFXClipAtPosition(AudioClip[] audioClips, Vector3 position, bool bypassesEffects = false, float volume = 1f, float pitch = 1f)
    {
        if (audioClips.Length == 0) return;

        int rand = Random.Range(0, audioClips.Length); // désigne un clip random dans l'array

        AudioSource audioSource = UseFromPool();
        audioSource.clip = audioClips[rand]; // assigne le clip random à l'auriosource
        audioSource.volume = volume; // assigne le volume à l'audiosource
        audioSource.pitch = pitch; // assigne le pitch aà l'audiosource

        audioSource.bypassEffects = bypassesEffects;

        audioSource.Play(); // joue le son

        float clipLength = audioSource.clip.length; // détermine la longueur du son

        StartCoroutine(HandleSoundEnd(audioSource, clipLength));
    }

    public AudioSource CreateModulableAudioSource()
    {
        AudioSource audioSource = UseFromPool();
        return audioSource;
    }

    /// <summary>
    /// gère le retour a la pool d'une audiosource s'arrêtant apres la fin de son clip
    /// </summary>
    /// <param name="source"></param>
    /// <param name="clipLength"></param>
    /// <returns></returns>
    IEnumerator HandleSoundEnd(AudioSource source, float clipLength)
    {
        yield return new WaitForSecondsRealtime(clipLength);
        BackToPool(source);
    }

    ////Singleton
    //private static AudioManager _instance = null;
    //public static AudioManager Instance => _instance;

    //public AudioSource sourceMusique ;
    //[SerializeField] AudioClip missileSound;
    //[SerializeField] AudioClip explosionSound;
    //[SerializeField] AudioClip jumpSound;
    //[SerializeField] AudioClip footstepSound;
    //[SerializeField] AudioClip fallSound;
    //[SerializeField] AudioClip flightSound;
    //[SerializeField] AudioClip coinSound;
    //[SerializeField] AudioClip powerUpSound;
    //[SerializeField] AudioClip bounceSound;
    //[SerializeField] AudioClip winSound;
    //[SerializeField] AudioClip deathSound;


    //private void Awake()
    //{
    //    //Singleton
    //    if (_instance != null && _instance != this)
    //    {
    //        Destroy(this.gameObject);
    //        return;
    //    }
    //    else
    //    {
    //        _instance = this;
    //        transform.SetParent(null);
    //        DontDestroyOnLoad(gameObject);
    //    }

    //    Debug.Log("te grosse mere");
    //    sourceMusique = GameObject.Find("Music Source").GetComponent<AudioSource>();
    //    //PlayMusic();
    //}
    //// all : pitch random entre 0.8 et 1
    //public void PlayMissile()
    //{
    //    PlaySound(missileSound,Random.Range(0.8f,1), 0.8f); // réduire volume
    //}
    //public void PlayExplosion()
    //{
    //    PlaySound(explosionSound, Random.Range(0.8f, 1), 0.8f) ; // réduire volume
    //}
    //public void PlayJump()
    //{
    //    PlaySound(jumpSound, Random.Range(0.8f, 1));
    //}
    //public void PlayFootsteps()
    //{
    //    PlaySound(footstepSound, Random.Range(0.8f, 1)); //suppr liste rdm ?
    //    //PlaySound(footstepSound); <- a tester avec le pitch / volume haut
    //}
    //public void PlayFall()
    //{
    //    PlaySound(fallSound, Random.Range(0.8f, 1)); // volume haut et pitch bas
    //}
    //public void PlayCoin() // réduire volume(?)
    //{
    //    PlaySound(coinSound, Random.Range(0.8f, 1));
    //}
    //public void PlayPowerUp()
    //{
    //    PlaySound(powerUpSound, Random.Range(0.8f, 1));
    //}
    //public void PlayBounce()
    //{
    //    PlaySound(bounceSound, Random.Range(0.8f, 1));
    //}
    //public void PlayWin()
    //{
    //    PlaySound(winSound);
    //}

    //public void PlaySound(AudioClip clip, float pitch = 1, float volume = 1)
    //{
    //    AudioSource source = gameObject.AddComponent<AudioSource>();
    //    source.volume = volume;
    //    source.pitch = pitch;
    //    source.PlayOneShot(clip);
    //    Destroy(source, 5);
    //}
    //public void PlayMusic()
    //{
    //    sourceMusique.Play();
    //}
    //public void StopMusic()
    //{
    //    sourceMusique.Stop();
    //}

    // Tous les sons sont trouvés sur pixabay.
    // musique par Karl Casey @ White Bat Audio
}
