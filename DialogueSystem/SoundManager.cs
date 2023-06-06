using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource source;
    public static SoundManager instance { get; private set; }
    void Awake()
    {
        instance = this;
    }

    public void PlaySound(AudioClip clip)
    {
        source.PlayOneShot(clip);
    }
    public void Mute(bool tf)
    {
        if (tf)
        {
        }
    }
}
