using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public bool isLastObstacleOfPreviousLevel;

    public void Init(float speed, bool isRightSide)
    {
        _rigidbody = GetComponent<Rigidbody>();
        if (isRightSide)
        {
            _rigidbody.AddForce(new Vector3(-speed, 0, -speed));
        }
        else
        {
            _rigidbody.AddForce(new Vector3(speed, 0, -speed));
        }
    }
}
