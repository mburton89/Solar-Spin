using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public static Ship Instance;

    public float spinningSpeed;
    public bool canSpin;

    [SerializeField] private ThrustParticleSpawner _leftParticleSpawner;
    [SerializeField] private ThrustParticleSpawner _rightParticleSpawner;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        canSpin = true;
    }

    void Update()
    {
        if (canSpin)
        {
            HandleKeyboard();
        }
    }

    public void HandleKeyboard()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _rightParticleSpawner.canSpawnParticle = false;
            transform.Rotate(0, -spinningSpeed * Time.deltaTime, 0, Space.Self);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            _leftParticleSpawner.canSpawnParticle = false;
            transform.Rotate(0, spinningSpeed * Time.deltaTime, 0, Space.Self);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            _rightParticleSpawner.canSpawnParticle = true;
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            _leftParticleSpawner.canSpawnParticle = true;
        }
    }

    void Splode()
    {
        //if (PlayerPrefs.GetInt("level") > 1)
        //{
        //    PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") - 2);
        //}
        //SpawnController.Instance.ChangeLevel(false);
        SessionManager.Instance.HandleDeath();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            Splode();
        }
    }
}
