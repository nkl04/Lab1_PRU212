using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour, ICollectable
{
    [SerializeField] private float speed = 1f;

    private Rigidbody2D rb2d;

    private void OnEnable()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = Vector2.down * speed;
    }

    public void DestroyStar()
    {
        gameObject.SetActive(false);
    }

    public void Collect()
    {
        ScoreSystem.Instance.AddScore(1);
        DestroyStar();
    }
}
