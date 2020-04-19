using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    private SpawnController _controller;
    private Obstacle _obstaclePrefab;
    private float _obstacleSpeed;
    [SerializeField] private bool _isRightSide;

    public void Init(SpawnController controller, Obstacle obstaclePrefab, float obstacleSpeed)
    {
        _controller = controller;
        _obstaclePrefab = obstaclePrefab;
        _obstacleSpeed = obstacleSpeed;
    }

    public void SpawnObstacle()
    {
        Obstacle obstacle = Instantiate(_obstaclePrefab, transform.position, transform.rotation);
        obstacle.Init(_obstacleSpeed, _isRightSide);
    }

    public void UpdateSpeed(float speed)
    {
        _obstacleSpeed = speed;
    }
}
