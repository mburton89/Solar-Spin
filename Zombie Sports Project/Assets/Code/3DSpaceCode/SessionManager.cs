using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SessionManager : MonoBehaviour
{
    public static SessionManager Instance;
    //[SerializeField] private Button _startButton;
    public int sunPosition;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        PlayerPrefs.SetInt("level", 0);
        PlayerPrefs.SetInt("deaths", 0);
        //_startButton.onClick.AddListener(StartGame);
    }

    void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void HandleDeath()
    {
        PlayerPrefs.SetInt("deaths", PlayerPrefs.GetInt("deaths") + 1);

        if (PlayerPrefs.GetInt("deaths") < 5)
        {
            //Sun.Instance.MoveToPosition(PlayerPrefs.GetInt("deaths"));
            SoundManager.Instance.PlayGameOverSound();
            StartCoroutine(DelayLoadScene(1));
        }
        else
        {
            PlayerPrefs.SetInt("level", 0);
            PlayerPrefs.SetInt("deaths", 0);
            SoundManager.Instance.PlayGameOverSound();
            TextDisplay.Instance.ShowText("Game Over");
            StartCoroutine(DelayLoadScene(0));
        }
    }

    private IEnumerator DelayLoadScene(int index)
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(index);
    }
}
