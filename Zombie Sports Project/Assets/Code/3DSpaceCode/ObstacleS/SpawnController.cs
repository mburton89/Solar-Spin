using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnController : MonoBehaviour
{
    public static SpawnController Instance;

    [SerializeField] private ObstacleSpawner _leftLeft;
    [SerializeField] private ObstacleSpawner _leftRight;
    [SerializeField] private ObstacleSpawner _rightLeft;
    [SerializeField] private ObstacleSpawner _rightRight;
    [SerializeField] private Obstacle _obstaclePrefab;
    [SerializeField] private GameObject _horizontalLinePrefab;
    [SerializeField] private Transform _lineSpawner;
    [SerializeField] private float _secondsBetweenSpawns;
    [SerializeField] private float _obstacleSpeed;
    [SerializeField] private List<float> _obstacleSpeedList;
    [SerializeField] private List<float> _secondsBetweenSpawnsList;
    [SerializeField] private List<float> _spinSpeedList;
    [SerializeField] private List<float> _secondsBeforeUpdatingSpeed;
    public int level;
    [SerializeField] private float _timeRemaining;
    private bool _canSpawn;
    private bool _hasSwitchedLevels;

    bool isOne; //For testing

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        if (PlayerPrefs.GetInt("level") == null)
        {
            PlayerPrefs.SetInt("level", 0);
        }
        level = PlayerPrefs.GetInt("level");

        _secondsBetweenSpawns = _secondsBetweenSpawnsList[level];
        _obstacleSpeed = _obstacleSpeedList[level];
        Ship.Instance.spinningSpeed = _spinSpeedList[level];
        Speedometer.Instance.ShowSpeed(level);
        _timeRemaining = 10f;
        _canSpawn = true;
        _hasSwitchedLevels = false;
        _leftLeft.Init(this, _obstaclePrefab, _obstacleSpeed);
        _leftRight.Init(this, _obstaclePrefab, _obstacleSpeed);
        _rightLeft.Init(this, _obstaclePrefab, _obstacleSpeed);
        _rightRight.Init(this, _obstaclePrefab, _obstacleSpeed);
        StartCoroutine(SpawnRandomScenario());
    }

    private void Update()
    {
        _timeRemaining -= Time.deltaTime;
        if (_timeRemaining < 0 && !_hasSwitchedLevels)
        {
            ChangeLevel(true);
            _hasSwitchedLevels = true;
        }
    }

    private IEnumerator SpawnRandomScenario()
    {
        if (_canSpawn)
        {
            int rand = Random.Range(0, 4);
            if (rand == 0)
            {
                SpawnScenarioOne();
            }
            else if (rand == 1)
            {
                SpawnScenarioTwo();
            }
            else if (rand == 2)
            {
                SpawnScenarioThree();
            }
            else
            {
                SpawnScenarioFour();
            }

            //if (isOne)
            //{
            //    SpawnScenarioOne();
            //    isOne = !isOne;
            //}
            //else
            //{
            //    SpawnScenarioThree();
            //    isOne = !isOne;
            //}

            //SpawnScenarioOne();

            GameObject horizotalLine = Instantiate(_horizontalLinePrefab, _lineSpawner.transform.position, transform.rotation);
            horizotalLine.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -_obstacleSpeed));
        }

        yield return new WaitForSeconds(_secondsBetweenSpawns);
        StartCoroutine(SpawnRandomScenario());
    }

    void SpawnScenarioOne()
    {
        _leftLeft.SpawnObstacle();
        _rightLeft.SpawnObstacle();
    }

    void SpawnScenarioTwo()
    {
        _leftRight.SpawnObstacle();
        _rightRight.SpawnObstacle();
    }

    void SpawnScenarioThree()
    {
        _leftLeft.SpawnObstacle();
        _leftRight.SpawnObstacle();
    }

    void SpawnScenarioFour()
    {
        _rightLeft.SpawnObstacle();
        _rightRight.SpawnObstacle();
    }

    public void ChangeLevel(bool shouldIncrease)
    {
        StartCoroutine(PauseForNextLevel(shouldIncrease));
    }

    private IEnumerator PauseForNextLevel(bool shouldIncrease)
    {
        if (!shouldIncrease)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        _canSpawn = false;
        yield return new WaitForSeconds(5);
        IncreaseLevel(shouldIncrease);
        _timeRemaining = 10f;
        _canSpawn = true;
        _hasSwitchedLevels = false;
        yield return new WaitForSeconds(_secondsBeforeUpdatingSpeed[level]);
        UpdateSpinningSpeed();
    }

    public void IncreaseLevel(bool shouldIncrease)
    {
        if (shouldIncrease)
        {
            if (level < 9)
            {
                level++;
            }
        }
        else
        {
            if (level > 0)
            {
                level--;
            }
        }

        _secondsBetweenSpawns = _secondsBetweenSpawnsList[level];
        _obstacleSpeed = _obstacleSpeedList[level];

        _leftLeft.UpdateSpeed(_obstacleSpeed);
        _leftRight.UpdateSpeed(_obstacleSpeed);
        _rightLeft.UpdateSpeed(_obstacleSpeed);
        _rightRight.UpdateSpeed(_obstacleSpeed);
    }

    public void UpdateSpinningSpeed()
    {
        PlayerPrefs.SetInt("level", level);
        Ship.Instance.spinningSpeed = _spinSpeedList[level];
        Speedometer.Instance.ShowSpeed(level);
        print("Ship.Instance.spinningSpeed " + Ship.Instance.spinningSpeed);
        SoundManager.Instance.PlayLevelUpSound();
    }
}
