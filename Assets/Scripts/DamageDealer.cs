using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageDealer : MonoBehaviour
{
    [SerializeField] protected LayerMask damageLayer;
    [SerializeField] protected float damage;
    protected abstract void OnTriggerEnter2D(Collider2D other);

}
