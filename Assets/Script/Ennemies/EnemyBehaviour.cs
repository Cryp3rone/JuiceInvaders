using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private float speed;

    private Vector3 direction;
    public Vector3 Direction 
    { 
        get { return direction; }
        set { direction = value; }
    }

    private EnemyManager manager;
    public EnemyManager Manager
    {
        get { return manager; }
        set { manager = value; }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += manager.Direction * speed * Time.deltaTime;
    }
}
