using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : DamageDealer
{
    [Header("Info")]
    [SerializeField] private float speed = 20f;
    [SerializeField] private float lifeTime = 2f;
    private float timeCounter = 0f;
    private Rigidbody2D rb2d;

    private void OnEnable()
    {
        timeCounter = lifeTime;
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = transform.up * speed;
    }
    private void Update()
    {
        if (timeCounter <= 0)
        {
            gameObject.SetActive(false);
        }
        else
        {
            timeCounter -= Time.deltaTime;
        }
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
            DestroySelf();
        }
    }

    private void DestroySelf()
    {
        gameObject.SetActive(false);
    }
}
