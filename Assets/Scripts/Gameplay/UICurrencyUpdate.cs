using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class UICurrencyUpdate : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private string _currentyName = "Gil";

    public void UpdateCurrency(int currency)
    {
        _text.SetText($"{currency} {_currentyName}");

    }
}
