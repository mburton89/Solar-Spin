using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextDisplay : MonoBehaviour
{
    public static TextDisplay Instance;

    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private float _secondsBetweenFlashes;
    public GameObject ffIcon;

    void Awake()
    {
        Instance = this;  
    }

    public void ShowText(string text)
    {
        StopAllCoroutines();
        StartCoroutine(FlashText(text));
    }

    private IEnumerator FlashText(string text)
    {
        _text.SetText(text);
        _text.gameObject.SetActive(true);
        yield return new WaitForSeconds(_secondsBetweenFlashes);
        _text.gameObject.SetActive(false);
        yield return new WaitForSeconds(_secondsBetweenFlashes);
        _text.gameObject.SetActive(true);
        yield return new WaitForSeconds(_secondsBetweenFlashes);
        _text.gameObject.SetActive(false);
        yield return new WaitForSeconds(_secondsBetweenFlashes);
        _text.gameObject.SetActive(true);
        yield return new WaitForSeconds(_secondsBetweenFlashes);
        _text.gameObject.SetActive(false);
    }
}
