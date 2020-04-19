using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrustParticle : MonoBehaviour
{
    public Rigidbody rigidbody;
    public float shrinkRate;

    public void Init()
    {
        InvokeRepeating("ApplyForce", 0.1f, 0.1f);
    }

    void ApplyForce()
    {
        rigidbody.AddForce(Vector3.back * 30);
        if (transform.localScale.x > 0)
        {
            transform.localScale -= new Vector3(shrinkRate, shrinkRate, shrinkRate);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
