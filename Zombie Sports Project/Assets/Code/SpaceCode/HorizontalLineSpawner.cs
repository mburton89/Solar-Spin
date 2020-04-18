using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalLineSpawner : MonoBehaviour
{
    [SerializeField] private HorizontalLine _horizontalLinePrefab;
    [SerializeField] private float _horizontalLineAcceleration;
    [SerializeField] private float _horizontalLineBeginningSpeed;
    [SerializeField] private float _secondsBetweenSpawns;
    [SerializeField] private float _ySpawnPosition;

    void Start()
    {
        StartCoroutine(SpawnHorizontalLines());
    }

    void SpawnHorizontalLine()
    {
        HorizontalLine newHorizontalLine = Instantiate(_horizontalLinePrefab, new Vector3(transform.position.x, _ySpawnPosition, 0), transform.rotation);
        newHorizontalLine.Init(_horizontalLineAcceleration, _horizontalLineBeginningSpeed);
    }

    private IEnumerator SpawnHorizontalLines()
    {
        SpawnHorizontalLine();
        yield return new WaitForSeconds(_secondsBetweenSpawns);
        StartCoroutine(SpawnHorizontalLines());
    }
}
