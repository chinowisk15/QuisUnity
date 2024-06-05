using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioSource MusicEffect;

    public AudioClip AudioCorrect;
    public AudioClip AudioWrong;
    public AudioClip AudioClick;

    public void PlayCorrect()
    {
        MusicEffect.PlayOneShot(AudioCorrect);
    }
    public void PlayWrong()
    {
        MusicEffect.PlayOneShot(AudioWrong);
    }
    public void PlayClick()
    {
        MusicEffect.PlayOneShot(AudioClick);
    }
    
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
