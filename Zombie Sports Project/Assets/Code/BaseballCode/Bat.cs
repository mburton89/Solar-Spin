using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    private Batter _batter;
    private AudioSource _audioSource;
    [SerializeField] private float _pop;

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Init(Batter batter)
    {
        _batter = batter;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ball")
        {
            Ball ball = collision.GetComponent<Ball>();
            if (!ball.hasBeenHit)
            {
                HitBall(collision.GetComponent<Ball>(), _batter.transform.eulerAngles.z);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Ball ball = collision.gameObject.GetComponent<Ball>();
            if (!ball.hasBeenHit)
            {
                HitBall(collision.gameObject.GetComponent<Ball>(), _batter.transform.eulerAngles.z);
            }
        }
    }

    void HitBall(Ball ball, float angle)
    {
        ball.hasBeenHit = true;
        print("Ball Hit! Batter at " + _batter.transform.eulerAngles.z + " angle.");
        Vector2 dir = (Vector2)(Quaternion.Euler(0, 0, angle) * Vector2.right);
        ball.rigidbody2D.velocity = Vector2.zero;
        ball.rigidbody2D.AddForce(dir * _pop);
        _audioSource.Play();
    }
}
