using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, ILivingEntity
{
    [Header("Health Info")]
    [SerializeField] private float maxHealth;
    [SerializeField] private ParticleSystem takeDamageEffect;
    public float Health { get; private set; }
    protected virtual void Awake()
    {
        Health = maxHealth;
    }
    public void TakeDamage(float damage)
    {
        Health -= damage;
        takeDamageEffect.Play();
        if (Health <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        gameObject.SetActive(false);
    }
}
