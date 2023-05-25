using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _pointB;
    [SerializeField] private float _timeBetweenPoints;

    private void Start()
    {
        transform.DOMoveX(_pointB, _timeBetweenPoints).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
            player.Die();
    }
}
