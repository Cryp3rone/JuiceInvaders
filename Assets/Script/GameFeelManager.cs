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

    public void Start()
    {
        instance = this;

        allowParticule = false;
        allowSprite = false;
    }

    public void OnParticuleToggle(InputValue inputValue)
    {
        allowParticule = !allowParticule;
        OnToggleParticule.Invoke(allowParticule);
    }

    public void OnPostprocessToggle(InputValue inputValue) 
    {
        allowPostProcess = !allowPostProcess;
        OnTogglePostProcess.Invoke(allowPostProcess);
    }

    public void OnSkinToggle(InputValue inputValue)
    {
        allowSprite = !allowSprite;
        OnToggleSprite.Invoke(allowSprite);
    }

}
