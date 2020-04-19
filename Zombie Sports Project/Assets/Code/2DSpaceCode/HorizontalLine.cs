using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalLine : MonoBehaviour
{
    private float _acceleration;
    private float _speed;

    public void Init(float acceleration, float speed)
    {
        _speed = speed;
        _acceleration = acceleration;
        Destroy(gameObject, 8);
    }

    void Update()
    {
        _speed += _acceleration;
        transform.position += Vector3.down * _speed * Time.deltaTime;
    }
}
