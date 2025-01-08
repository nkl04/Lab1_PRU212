using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectScore : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        ICollectable collectable = other.GetComponent<ICollectable>();
        collectable?.Collect();
    }
}
