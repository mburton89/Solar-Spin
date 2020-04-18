using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] private Zombie _zombiePrefab;
    [SerializeField] private float _zombieAcceleration;
    [SerializeField] private float _zombieMaxWalkSpeed;
    [SerializeField] private float _secondsBetweenSpawns;
    [SerializeField] private float _ySpawnPosition;
    [SerializeField] private float _xSpawnPositionMax;

    void Start()
    {
        StartCoroutine(SpawnZombies());
    }

    void SpawnZombie()
    {
        float randomXPosition = Random.Range(-_xSpawnPositionMax, _xSpawnPositionMax);
        Zombie newZombie = Instantiate(_zombiePrefab, new Vector3(randomXPosition, _ySpawnPosition, 0), transform.rotation);
        newZombie.Init(_zombieAcceleration, _zombieMaxWalkSpeed);
    }

    private IEnumerator SpawnZombies()
    {
        SpawnZombie();
        yield return new WaitForSeconds(_secondsBetweenSpawns);
        StartCoroutine(SpawnZombies());
    }
}
