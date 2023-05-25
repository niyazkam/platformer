using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    [SerializeField] private AudioSource _sound;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private CircleCollider2D _collider;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _sound.Play();
            _spriteRenderer.enabled = false;
            _collider.enabled = false;
            player.AddGem();
            Destroy(gameObject, _sound.clip.length);
        }
    }
}
