using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    [SerializeField] protected GameObject prefab;

    [SerializeField] protected float spawnRate = 1f;

    protected float spawnTimer = 0f;

    protected virtual void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnRate)
        {
            Spawn();
            spawnTimer = 0f;
        }
    }

    public abstract void Spawn();
}
