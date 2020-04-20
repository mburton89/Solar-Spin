using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] private AudioSource _start;
    [SerializeField] private AudioSource _levelUp;
    [SerializeField] private AudioSource _gameOver;
    [SerializeField] private AudioSource _thrust;

    private void Awake()
    {
        Instance = this;
    }

    public void PlayStartSound()
    {
        _start.Play();
    }

    public void PlayLevelUpSound()
    {
        _levelUp.Play();
    }

    public void PlayGameOverSound()
    {
        _gameOver.Play();
    }

    public void PlayThrustSound()
    {
        _thrust.volume = 1;
    }

    public void StopThrustSound()
    {
        _thrust.volume = 0;
    }
}
