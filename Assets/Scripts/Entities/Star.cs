using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Star : MonoBehaviour, ICollectable
{
    [SerializeField] private float lifeTime = 5f;
    private float timeCounter;
    private SpriteRenderer spriteRenderer;

    private Tween blinkTween;
    private void OnEnable()
    {
        timeCounter = lifeTime;
    }

    private void Start()
    {
        spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        timeCounter -= Time.deltaTime;

        if (timeCounter <= lifeTime * 0.3f && blinkTween == null)
        {
            StartBlinking();
        }

        if (timeCounter <= 0)
        {
            DestroyStar();
        }
    }

    public void DestroyStar()
    {
        blinkTween?.Kill();
        gameObject.SetActive(false);
    }

    public void Collect()
    {
        ScoreSystem.Instance.AddScore(1);
        DestroyStar();
    }

    private void StartBlinking()
    {
        float blinkDuration = lifeTime * 0.3f;
        blinkTween = spriteRenderer.DOFade(0f, 0.2f)
            .SetLoops(-1, LoopType.Yoyo)
            .OnKill(() =>
            {
                spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1f);
            });

        DOVirtual.DelayedCall(blinkDuration, () =>
        {
            blinkTween?.Kill();
        });
    }

    private void OnDisable()
    {
        blinkTween?.Kill();
    }
}
