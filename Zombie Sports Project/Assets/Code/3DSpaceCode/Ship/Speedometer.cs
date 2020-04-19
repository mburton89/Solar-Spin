using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Speedometer : MonoBehaviour
{
    public static Speedometer Instance;
    [SerializeField] private TextMeshProUGUI _speedAmountText;
    [SerializeField] private List<Image> _fills;
    [HideInInspector] public int currentSpeed;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowSpeed(int speed)
    {
        currentSpeed = speed;
        for (int i = 0; i < speed; i++)
        {
            _fills[i + 1].enabled = true;
        }
        _speedAmountText.SetText((currentSpeed + 1).ToString());
    }

    public void ShowNextSpeed()
    {
        currentSpeed++;
        _fills[currentSpeed].enabled = true;
        _speedAmountText.SetText(currentSpeed.ToString());
    }

    public void ShowPreviousSpeed()
    {
        _fills[currentSpeed].enabled = false;
        currentSpeed--;
        _fills[currentSpeed].enabled = true;
        _speedAmountText.SetText(currentSpeed.ToString());
    }
}
