using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("Bounding")] 
    [SerializeField] private Vector2 min;
    [SerializeField] private Vector2 max;
    
    [Space]
    [Header("Other")]
    [SerializeField] private float _speed;
    [SerializeField] private float _cooldown;
    [SerializeField] private GameObject _bullet;
    
    private Rigidbody2D _rb;
    private Vector2 _movement;
    private bool _canShoot = true;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        transform.position = new Vector2(
            Mathf.Clamp(transform.position.x, min.x, max.x),Mathf.Clamp(transform.position.y, min.y, max.y));
    }

    void FixedUpdate()
    {
         // if (transform.position.x < min.x)
         // {
         //     _rb.AddForce(new Vector2(1,0));
         // }
         // else if (transform.position.y > max.x)
         // {
         //     _rb.AddForce(new Vector2(-1,0));
         // }
            
         _rb.velocity = _movement * _speed;
        
         // if(transform.position.y <= _maxUpPosition)
         //     _rb.velocity = _movement * _speed;
         // else
         //     _rb.velocity = Vector2.zero;

    }

    private void OnMove(InputValue inputValue)
    {
        _movement = inputValue.Get<Vector2>();
    }

    private void OnFire(InputValue inputValue)
    {
        if (_canShoot)
        {
            Instantiate(_bullet, transform);
            StartCoroutine(Cooldown(_cooldown));
        }
    }

    IEnumerator Cooldown(float time)
    {
        _canShoot = false;

        yield return new WaitForSeconds(time);

        _canShoot = true;
    }
}
