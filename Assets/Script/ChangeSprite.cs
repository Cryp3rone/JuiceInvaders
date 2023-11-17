using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    [SerializeField] private Sprite skin, noskin;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private bool changeColor = false;
    private Color randomColor;

    public void Start()
    {
        GameFeelManager.instance.OnToggleSprite.AddListener(OnChangeSprite);
        randomColor = Random.ColorHSV(0, 1, 0, 1, 0.5f, 1 );
    }

    private void OnChangeSprite(bool allowSprite)
    {
        spriteRenderer.sprite = allowSprite ? skin : noskin;
        spriteRenderer.color = changeColor && allowSprite ? randomColor : Color.white;
    }
}
