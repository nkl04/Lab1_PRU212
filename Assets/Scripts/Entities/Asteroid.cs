using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [Header("Info")]
    [Header("Range Settings")]
    [SerializeField][Range(0, 20)] private float minRotationSpeed = 0f;
    [SerializeField][Range(0, 20)] private float maxRotationSpeed = 10f;
    private float rotateSpeed;


    [Header("Visual")]
    [SerializeField] private List<Sprite> sprites;

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
}
