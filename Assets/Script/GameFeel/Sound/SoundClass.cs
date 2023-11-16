using UnityEngine.Audio;
using UnityEngine;


[System.Serializable]
public class SoundClass
{

    public string name;

    public AudioClip[] clips;

    [Range(0f, 1f)]
    public float volume = .5f;

    [Range(-3f, 3f)]
    public float pitch = 1;

    public bool loop;

    public bool playOnAwake;

    [HideInInspector]
    public AudioSource source;
}

