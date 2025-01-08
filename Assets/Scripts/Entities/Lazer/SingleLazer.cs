using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleLazer : MonoBehaviour
{
    [Header("Info")]
    [SerializeField]
    private float speed = 20f;
    [SerializeField]
    private float lifeTime = 2f;

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
}
