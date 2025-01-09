using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [Header("Info")]
    [SerializeField][Range(0, 20)] private float rotateSpeed;


    [Header("Visual")]
    [SerializeField] private List<Sprite> sprites;

    private Transform child;

    private void Start()
    {
        child = transform.GetChild(0);
        child.GetComponent<SpriteRenderer>().sprite = sprites[UnityEngine.Random.Range(0, sprites.Count)];
    }
    private void Update()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * rotateSpeed);
    }
}
