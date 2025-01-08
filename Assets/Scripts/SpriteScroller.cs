using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteScroller : MonoBehaviour
{
    [SerializeField] private Vector2 speedVector;
    private Vector2 offset;
    private Material material;

    private void Start()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    private void Update()
    {
        offset = speedVector * Time.deltaTime;
        material.mainTextureOffset += offset;
    }



}
