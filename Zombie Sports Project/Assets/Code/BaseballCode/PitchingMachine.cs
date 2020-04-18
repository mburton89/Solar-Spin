using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitchingMachine : MonoBehaviour
{
    [SerializeField] private Ball _baseballPrefab;
    [SerializeField] private float _throwSpeed;
    [SerializeField] private float _secondsBetweenPitches;

    void Start()
    {
        StartCoroutine(PitchBaseballs());
    }

    void PitchBaseball()
    {
        Ball newBaseball = Instantiate(_baseballPrefab, transform.position, transform.rotation);
        newBaseball.rigidbody2D.AddForce(Vector2.down * _throwSpeed);
        Destroy(newBaseball, 5);
    }

    private IEnumerator PitchBaseballs()
    {
        PitchBaseball();
        yield return new WaitForSeconds(_secondsBetweenPitches);
        StartCoroutine(PitchBaseballs());
    }
}
