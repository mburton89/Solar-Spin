using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private List<Sprite> _sprites;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    private float _acceleration;
    private float _maxWalkSpeed;
    private AudioSource _audioSource;

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Init(float acceleration, float maxWalkSpeed)
    {
        _acceleration = acceleration;
        _maxWalkSpeed = maxWalkSpeed;
    }

    private void Update()
    {
        Walk(Vector2.down);
    }

    void FixedUpdate()
    {
        if (_rigidbody2D.velocity.magnitude > _maxWalkSpeed)
        {
            _rigidbody2D.velocity = _rigidbody2D.velocity.normalized * _maxWalkSpeed;
        }
    }

    void Walk(Vector2 direction)
    {
        _rigidbody2D.AddForce(direction * _acceleration);
    }

    public void SplodeHead()
    {
        _spriteRenderer.sprite = _sprites[1];
        Destroy(gameObject, 2);
        _audioSource.Play();    
    }
}
