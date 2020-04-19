using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    public static Sun Instance;
    public List<float> yPositions;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        MoveToPosition(PlayerPrefs.GetInt("deaths"));
    }

    public void MoveToPosition(int index)
    {
        transform.position = new Vector3(transform.position.x, yPositions[index], transform.position.z);
    }
}
