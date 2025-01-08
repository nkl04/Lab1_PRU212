using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : Spawner
{
    public override void Spawn()
    {
        GameObject star = ObjectPooler.Instance.GetObjectFromPool(prefab.name);
        star.transform.position = new Vector3(
            Random.Range(MainCamera.Instance.MinMoveableBounds.x, MainCamera.Instance.MaxMoveableBounds.x),
            Random.Range(MainCamera.Instance.MinMoveableBounds.y, MainCamera.Instance.MaxMoveableBounds.y),
            0
        );

        star.SetActive(true);
    }
}
