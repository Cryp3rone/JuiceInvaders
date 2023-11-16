using UnityEngine.Audio;
using UnityEngine;
using System;


public class MasterSoundManager : MonoBehaviour
{

    public static MasterSoundManager instance;
    public SoundClass[] Sounds;

    public bool PlayThemeSongOnAwake = true;

    public bool pressed;
    bool done;

    public bool shouldDestroyOnLoad;

    // Update is called once per frame
    void Awake()
    {
        if(!done)
        {
            if(instance != null)
            {
                Debug.LogWarning("Il y a plus d'une instance de MasterSoundManager dans la scène, ce dernier va être supprimé");
                Destroy(this.gameObject);
            }
            instance = this;
            foreach (SoundClass sound in Sounds)
            {
                sound.source = gameObject.AddComponent<AudioSource>();
                sound.source.clip = sound.clips[0];

                sound.source.volume = sound.volume;

                sound.source.pitch = sound.pitch;

                sound.source.loop = sound.loop;

                sound.source.playOnAwake = sound.playOnAwake;

                // sound.source.outputAudioMixerGroup = audioMixer.FindMatchingGroups("Master");
            }
            if(!shouldDestroyOnLoad)
            {
                DontDestroyOnLoad(this.gameObject);
            }

            if(PlayThemeSongOnAwake)
            {
                ChangeThemeSong(0);
            }

            done = true;
        }
    }

    private void Start()
    {
        GameFeelManager gameFeelManager = GameFeelManager.instance;

        gameFeelManager.OnToggleThemeSong.AddListener(i => ChangeState(i, "ThemeSong"));
        gameFeelManager.OnToggleHitSong.AddListener(i => ChangeState(i, "Tirs"));
        gameFeelManager.OnToggleFlowerDeathSong.AddListener(i => ChangeState(i, "FlowerDeath"));
    }

    public void Play (string name)
    {
        SoundClass sFound = Array.Find(Sounds, sound => sound.name == name);
        int integ = 0;
        int soundToPlay = UnityEngine.Random.Range(integ, sFound.clips.Length);
      
        sFound.source.clip = sFound.clips[soundToPlay];
        sFound.source.Play();
        Debug.Log(sFound.source.clip + " " + sFound.source + " " + soundToPlay);
        Debug.Log("AudioPlayed");
    }

    private void Update() 
    {
        if(pressed)
        {
            Play("Hit");
            pressed = false;
        }
    }
    
    public void ChangeThemeSong (int songNumber)
    {
        SoundClass sFound = Array.Find(Sounds, sound => sound.name == "ThemeSong");
        sFound.source.clip = sFound.clips[songNumber];
        sFound.source.Play();
    }

    public void StopTS ()
    {
        SoundClass sFound = Array.Find(Sounds, sound => sound.name == "ThemeSong");
        sFound.source.Stop();
    }


    public AudioClip getAudioClip(string name)
    {
        SoundClass sFound = Array.Find(Sounds, sound => sound.name == name);
        return sFound.source.clip;
    }

    public AudioSource getAudioSource(string name)
    {
        SoundClass sFound = Array.Find(Sounds, sound => sound.name == name);
        return sFound.source;
    }

    public SoundClass getSoundClass(string name)
    {
        SoundClass sFound = Array.Find(Sounds, sound => sound.name == name);
        return sFound;
    }

    public void StopSound (string name)
    {
        SoundClass sFound = Array.Find(Sounds, sound => sound.name == name);
        sFound.source.Stop();
    }

    public void ChangeState(bool isActive,string name)
    {
        SoundClass sFound = Array.Find(Sounds, sound => sound.name == name);
        sFound.source.volume = isActive ? sFound.defaultVolume : 0;
    }
}
    
