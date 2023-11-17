using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

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
         _rb.velocity = _movement * _speed;
    }

    private void OnMove(InputValue inputValue)
    {
        _movement = inputValue.Get<Vector2>();
    }

    private void OnFire(InputValue inputValue)
    {
        if (_canShoot)
        {
            Instantiate(_bullet, new Vector3(Mathf.Clamp(transform.position.x, min.x, max.x), Mathf.Clamp(transform.position.y, min.y, max.y), 0), Quaternion.identity);
            MasterSoundManager.instance.Play("Tirs");
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
