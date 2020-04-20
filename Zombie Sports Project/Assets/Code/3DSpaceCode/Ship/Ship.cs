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

    public float shrinkRate;

    private Vector3 _initialScale;

    public float cheatSpeed;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        canSpin = true;
        SoundManager.Instance.PlayStartSound();
        TextDisplay.Instance.ShowText("Lets Go!");
        _initialScale = transform.localScale;
        Time.timeScale = 1;
    }

    void Update()
    {
        if (canSpin)
        {
            HandleKeyboard();
        }

        if (!canSpin)
        {
            _leftParticleSpawner.canSpawnParticle = false;
            _rightParticleSpawner.canSpawnParticle = false;
            float x = _initialScale.x + Random.Range(-0.5f, 0.5f);
            float y = _initialScale.y + Random.Range(-0.5f, 0.5f);
            float z = _initialScale.z + Random.Range(-0.5f, 0.5f);

            transform.localScale = new Vector3(x, y, z);

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

        if (Input.GetKey(KeyCode.UpArrow))
        {
            Time.timeScale = cheatSpeed;
            TextDisplay.Instance.ffIcon.SetActive(true);
        }

        //if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    SoundManager.Instance.PlayThrustSound();
        //}

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            _rightParticleSpawner.canSpawnParticle = true;
            //SoundManager.Instance.StopThrustSound();
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            _leftParticleSpawner.canSpawnParticle = true;
            //SoundManager.Instance.StopThrustSound();
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            Time.timeScale = 1;
            TextDisplay.Instance.ffIcon.SetActive(false);
        }
    }

    void Splode()
    {
        //if (PlayerPrefs.GetInt("level") > 1)
        //{
        //    PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") - 2);
        //}
        //SpawnController.Instance.ChangeLevel(false);
        canSpin = false;
        SessionManager.Instance.HandleDeath();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle" && canSpin)
        {
            Splode();
        }
    }
}
