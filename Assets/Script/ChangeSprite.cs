using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    [SerializeField] private Sprite skin, noskin;
    [SerializeField] private SpriteRenderer spriteRenderer;

    public void Start()
    {
        GameFeelManager.instance.OnToggleSprite.AddListener(OnChangeSprite);
    }

    private void OnChangeSprite(bool allowSprite)
    {
        spriteRenderer.sprite = allowSprite ? skin : noskin;
    }
}
