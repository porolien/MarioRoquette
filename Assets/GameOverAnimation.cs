using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameOverAnimation : MonoBehaviour
{

    private static GameOverAnimation _instance = null;
    public static GameOverAnimation Instance => _instance;
    public AudioClip deathSound;
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
            transform.SetParent(null);
            DontDestroyOnLoad(gameObject);
        }
    }


    public void Play()
    {
        GetComponentInChildren<Animation>().Play();
        //AudioManager.Instance.PlayDeath();

    }

    public void PlayDeath()
    {
        PlaySound(deathSound);
    }
    public void PlaySound(AudioClip clip, float pitch = 1, float volume = 1)
    {
        AudioSource source = gameObject.AddComponent<AudioSource>();
        DontDestroyOnLoad(source.gameObject);
        source.volume = volume;
        source.pitch = pitch;
        source.PlayOneShot(clip);
        Destroy(source, 2);
    }
}
