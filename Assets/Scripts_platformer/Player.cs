using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private AudioSource _dieSound;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private BoxCollider2D _collider;

    private int _gems = 0;
    
    public void AddGem()
    {
        _gems++;
    }

    public void Die()
    {
        _dieSound.Play();
        _spriteRenderer.enabled = false;
        _collider.enabled = false;
        Destroy(gameObject, _dieSound.clip.length);
    }
}
