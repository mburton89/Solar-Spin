using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] private AudioSource _levelUp;

    private void Awake()
    {
        Instance = this;
    }

    public void PlayLevelUpSound()
    {
        _levelUp.Play();
    }
}
