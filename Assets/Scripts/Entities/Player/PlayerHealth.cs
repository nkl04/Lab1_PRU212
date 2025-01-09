using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [Header("Health Info")]
    [SerializeField] private float maxHealth;
    [SerializeField] private ParticleSystem takeDamageEffect;
    public float Health { get; private set; }
    protected virtual void Awake()
    {
        Health = maxHealth;
    }

    public void Die()
    {
        gameObject.SetActive(false);
        DebugLog.LogError("You lose!");
        DebugLog.LogGreen("Your score:" + ScoreSystem.Instance.Score);
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
        if (takeDamageEffect != null) takeDamageEffect.Play();
        if (Health <= 0)
        {
            Die();
        }
    }
}
