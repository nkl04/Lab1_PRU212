using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : DamageDealer, IDamageable
{
    [Header("Info")]
    [SerializeField][Range(0, 20)] private float minRotationSpeed = 0f;
    [SerializeField][Range(0, 20)] private float maxRotationSpeed = 10f;
    private float rotateSpeed;

    [SerializeField] private float health;


    [Header("Visual")]
    [SerializeField] private List<Sprite> sprites;
    [SerializeField] private ParticleSystem explosionParticle;

    private Transform child;

    private void Start()
    {
        child = transform.GetChild(0);
        child.GetComponent<SpriteRenderer>().sprite = sprites[UnityEngine.Random.Range(0, sprites.Count)];

        RandomRotationSpeed();
    }
    private void Update()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * rotateSpeed);
    }

    private void RandomRotationSpeed()
    {
        rotateSpeed = UnityEngine.Random.Range(minRotationSpeed, maxRotationSpeed);
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (damageLayer == (damageLayer | (1 << other.gameObject.layer)))
        {
            IDamageable livingEntity = other.GetComponent<IDamageable>();
            if (livingEntity != null)
            {
                livingEntity.TakeDamage(damage);
            }
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (explosionParticle != null)
        {
            explosionParticle.Play();
        }
        if (health <= 0)
        {
            Die();
        }

    }

    public void Die()
    {
        gameObject.SetActive(false);
    }
}
