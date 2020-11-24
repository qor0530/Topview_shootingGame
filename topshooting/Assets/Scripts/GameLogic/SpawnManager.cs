using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public int Enemy_Term = 30;
    private int Enemy_Term_Count = 0;

    void Update()
    {
        if (!GameScene.Instance.isPlaying)
            return;

        if(Enemy_Term_Count++ >= Enemy_Term)
        {
            Spawn();
            Enemy_Term_Count = 0;
        }
    }

    private void Spawn()
    {
        var enemyPrefab = Resources.Load("Prefabs/EnemyGroup") as GameObject;
        var enemyObject = Instantiate(enemyPrefab);

        enemyObject.transform.position = transform.position;
    }
}
