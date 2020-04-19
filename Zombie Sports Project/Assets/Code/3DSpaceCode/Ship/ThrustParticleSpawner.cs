using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrustParticleSpawner : MonoBehaviour
{
    [SerializeField] private ThrustParticle _thrustParticlePrefab;
    [SerializeField] private float _backwardForce;

    [HideInInspector] public bool canSpawnParticle;

    void Start()
    {
        canSpawnParticle = true;
        InvokeRepeating("SpawnParticle", 0.1f, 0.02f);
    }

    void SpawnParticle()
    {
        if (canSpawnParticle)
        {
            float randX = Random.Range(-3, 3);
            float randY = Random.Range(-3, 3);

            ThrustParticle thrustParticle = Instantiate(_thrustParticlePrefab, new Vector3(transform.position.x + randX / 10, transform.position.y + randY / 10, transform.position.z), transform.rotation);

            Vector3 forceToApply = new Vector3(randX, randY, -_backwardForce);
            thrustParticle.rigidbody.AddRelativeForce(forceToApply * 2);
            thrustParticle.Init();
        }
    }
}
