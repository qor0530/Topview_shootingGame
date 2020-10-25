using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public int EnemyTerm = 40;
    public int EnemyTermCount = 0;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (EnemyTermCount++ >= EnemyTerm)
        {
            Spawn();
            EnemyTermCount = 0;
        }
    }

    private void Spawn()
    {
        var enemyPrefab = Resources.Load("Prefab/EnemyGroup") as GameObject;
        var enemyObject = Instantiate(enemyPrefab);
        enemyObject.transform.position = transform.position;
    }
}