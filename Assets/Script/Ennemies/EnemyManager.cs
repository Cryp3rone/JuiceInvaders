using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab, spawnPos;
    [SerializeField] public GameObject rightWall, leftWall;
    [SerializeField] private float enemyOffset;
    [SerializeField] private int nbEnemyPerLine, nbLine;
    [SerializeField] private List<EnemyBehaviour> listEnemies = new List<EnemyBehaviour>();
    [SerializeField] private float lineOffset;
    private Vector3 direction;
    public Vector3 Direction
    {
        get { return direction; }
        set { direction = value; }
    }

    public void Start()
    {
        Direction = Vector3.right;
        Vector3 pos = spawnPos.transform.position;

        for(int i = 0; i < nbLine; i++)
        {
            for(int j = 0; j < nbEnemyPerLine; j++)
            {
                Transform enemyTransform = Instantiate(enemyPrefab.transform, pos, Quaternion.identity);
                enemyTransform.TryGetComponent<EnemyBehaviour>(out EnemyBehaviour enemy);
                enemy.Manager = this;
                enemy.Direction = Direction;
                listEnemies.Add(enemy);

                pos.x += enemyOffset;
            }
            pos.x = spawnPos.transform.position.x;
            pos.y -= enemyOffset;
        }
    }

    public void Update()
    {
        if (listEnemies == null || listEnemies.Count < 0)
            return;

        if(listEnemies.Max(i => i.transform.position.x) > rightWall.transform.position.x && direction == Vector3.right || listEnemies.Min(i => i.transform.position.x) < leftWall.transform.position.x && direction == Vector3.left)
        {
            ChangeLine();
        }
    }

    public void ChangeLine()
    {
        direction = direction == Vector3.right ? Vector3.left : Vector3.right;
        listEnemies.ForEach((e) =>
        {
            e.transform.position += Vector3.down * lineOffset;
        });
    }

    public void Kill(EnemyBehaviour enemy)
    {
        listEnemies.Remove(enemy);
        Destroy(enemy.gameObject);
    }
}
