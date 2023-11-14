using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyBehavoir : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector3 direction;
    public Vector3 Direction 
    { 
        get { return direction; }
        set { direction = value; }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
