using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _flyingTime;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        _rb.velocity = Vector2.up * _bulletSpeed;
        StartCoroutine(FlyingTIme(_flyingTime));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("hey");
        Destroy(gameObject);
    }

    IEnumerator FlyingTIme(float flyingTime)
    {
        yield return new WaitForSeconds(flyingTime);
        Destroy(gameObject);
    }
}
