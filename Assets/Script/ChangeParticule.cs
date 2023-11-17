using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeParticule : MonoBehaviour
{
    [SerializeField] private GameObject particule;

    public void Start()
    {
        particule.SetActive(GameFeelManager.instance.allowParticule);
        GameFeelManager.instance.OnToggleParticule.AddListener(OnChangeParticule);
    }

    private void OnChangeParticule(bool allowSprite)
    {
        particule.SetActive(allowSprite);
    }
}
