using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundClip
{
    Hit,
    Dash,
    Jump,
}

public class SFXManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] _soundClip;
    [SerializeField]
    private AudioSource SFXSource;
    private static SFXManager instance;

    private void Awake()
    {
        instance = this;
    }

    public static void PlaySound(SoundClip soundClip)
    {
        instance.SFXSource.PlayOneShot(instance._soundClip[(int)soundClip]);
    }
}
