using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class GameFeelManager : MonoBehaviour
{
    public static GameFeelManager instance;

    public UnityEvent<bool> OnToggleParticule = new UnityEvent<bool>();
    public bool allowParticule;
    public UnityEvent<bool> OnToggleSprite = new UnityEvent<bool>();
    public bool allowSprite;
    public UnityEvent<bool> OnTogglePostProcess = new UnityEvent<bool>();
    public bool allowPostProcess;

    public UnityEvent<bool> OnToggleThemeSong = new UnityEvent<bool>();
    public bool allowThemeSong;
    public UnityEvent<bool> OnToggleHitSong = new UnityEvent<bool>();
    public bool allowHitSong;
    public UnityEvent<bool> OnToggleFlowerDeathSong = new UnityEvent<bool>();
    public bool allowFlowerDeathSong;


    private void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        allowParticule = false;
        allowSprite = false;
        allowPostProcess = false;
        allowThemeSong = false;
        allowHitSong = false;
        allowFlowerDeathSong = false;

        OnToggleParticule.Invoke(false);
        OnToggleSprite.Invoke(false);
        OnTogglePostProcess.Invoke(false);
        OnToggleThemeSong.Invoke(false); 
        OnToggleHitSong.Invoke(false);
        OnToggleFlowerDeathSong.Invoke(false);
    }

    public void OnParticuleToggle(InputValue inputValue)
    {
        allowParticule = !allowParticule;
        OnToggleParticule.Invoke(allowParticule);
    }

    public void OnPostProcessToggle(InputValue inputValue) 
    {
        allowPostProcess = !allowPostProcess;
        OnTogglePostProcess.Invoke(allowPostProcess);
    }

    public void OnSkinToggle(InputValue inputValue)
    {
        allowSprite = !allowSprite;
        OnToggleSprite.Invoke(allowSprite);
    }

    public void OnThemeSongToggle(InputValue inputValue)
    {
        allowThemeSong = !allowThemeSong;
        OnToggleThemeSong.Invoke(allowThemeSong);
    }

    public void OnHitSongToggle(InputValue inputValue)
    {
        allowHitSong = !allowHitSong;
        OnToggleHitSong.Invoke(allowHitSong);
    }

    public void OnFlowerDeathToggle(InputValue inputValue)
    {
        allowFlowerDeathSong = !allowFlowerDeathSong;
        OnToggleFlowerDeathSong.Invoke(allowFlowerDeathSong);
    }

}
