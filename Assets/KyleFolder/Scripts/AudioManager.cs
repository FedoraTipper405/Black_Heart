using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundClip
{
    Hit,
    Dash,
    Jump,
    BloodSplat,
    Scream,
    DeathScream,
}

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] _soundClip;
    [SerializeField]
    private AudioSource SFXSource;
    [SerializeField]
    private AudioSource MusicSource;
    [SerializeField]
    private AudioClip _musicClip;
    private static AudioManager instance;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        MusicSource.clip = _musicClip;
        MusicSource.Play();
    }

    public static void PlaySound(SoundClip soundClip)
    {
        instance.SFXSource.PlayOneShot(instance._soundClip[(int)soundClip]);
    }
}
