using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Energometer : MonoBehaviour
{
    public static Energometer Instance;
    [SerializeField] private TextMeshProUGUI _sunAmountText;
    [SerializeField] private List<Image> _fills;
    [HideInInspector] public int currentSunAmount;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        ShowSunAmmount(PlayerPrefs.GetInt("deaths"));
    }

    public void ShowSunAmmount(int sunAmount)
    {
        currentSunAmount = 5 - sunAmount;
        for (int i = 0; i < sunAmount; i++)
        {
            _fills[i].enabled = false;
        }
        _sunAmountText.SetText(currentSunAmount + "/5");
    }
}
