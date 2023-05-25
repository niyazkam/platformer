using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpVelocity;
    [SerializeField] private LayerMask _groundLayerMask;
    [SerializeField] private Animator _animator;

    private Rigidbody2D _rigidbody2D;
    private BoxCollider2D _boxCollider2D;
    private float _extraHeight = 0.1f;
    private float _move;
    private Color _rayColor;
    private bool _facingRight = true;
    private int _speedAnimatorHash = Animator.StringToHash("Speed");

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    private void Update()
    {
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody2D.velocity = Vector2.up * _jumpVelocity; 
        }
        
        _move = Input.GetAxis("Horizontal");
        _animator.SetFloat(_speedAnimatorHash, Mathf.Abs(_move));

        if (_move > 0f && _facingRight == false)
            Flip();
        else if (_move < 0f && _facingRight)
            Flip();
    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = new Vector2(_move * _moveSpeed, _rigidbody2D.velocity.y);
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.Raycast(_boxCollider2D.bounds.center, Vector2.down, 
            _boxCollider2D.bounds.extents.y + _extraHeight, 
            _groundLayerMask);

        if (raycastHit2D.collider != null)
            _rayColor = Color.green;
        else
            _rayColor = Color.red;

        Debug.DrawRay(_boxCollider2D.bounds.center, 
            Vector2.down * (_boxCollider2D.bounds.extents.y + _extraHeight), _rayColor);
        return raycastHit2D.collider != null;
    }

    private void Flip()
    {
        _facingRight = !_facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
