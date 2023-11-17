using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBackGround : MonoBehaviour
{
    [SerializeField] private GameObject backGroud;

    public void Start()
    {
        backGroud.SetActive(GameFeelManager.instance.allowBackGround);
        GameFeelManager.instance.OnToggleBackGround.AddListener(OnChangeBG);
    }

    private void OnChangeBG(bool allowSprite)
    {
        backGroud.SetActive(allowSprite);
    }
}
