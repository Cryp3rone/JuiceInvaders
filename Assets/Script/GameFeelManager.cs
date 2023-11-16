using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameFeelManager : MonoBehaviour
{
    public static GameFeelManager instance;

    public bool allowParticule;
    public bool allowSprite;
    public bool allowPostProcess;

    public void Start()
    {
        instance = this;

        allowParticule = false;
        allowSprite = false;
    }

    public void OnParticleToggle(InputValue inputValue)
    {
        allowParticule = !allowParticule;
    }

    public void OnPostProcessToggle(InputValue inputValue) 
    {
        allowPostProcess = !allowPostProcess;
    }

    public void OnSkinToggle(InputValue inputValue)
    {
        allowSprite = !allowSprite;
    }

}
