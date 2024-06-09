using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController Instance;

    private AudioSource _audio;

    private void Awake()
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
        _audio = GetComponent<AudioSource>();
    }


    public void PlaySound(AudioClip sonido)
    {
        _audio.PlayOneShot(sonido);
    }
}
