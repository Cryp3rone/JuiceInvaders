using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _flyingTime;
    [SerializeField] private Sprite skin, noskin;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = GameFeelManager.instance.allowSprite ? skin : noskin;
        _rb.velocity = Vector2.up * _bulletSpeed;
        StartCoroutine(FlyingTIme(_flyingTime));
    }

    IEnumerator FlyingTIme(float flyingTime)
    {
        yield return new WaitForSeconds(flyingTime);
        Destroy(gameObject);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision != null && collision.gameObject.tag == "Enemy") 
        {
            collision.gameObject.TryGetComponent(out EnemyBehaviour enemmy);
            enemmy.Death();
            Destroy(gameObject);
        }
    }
}
