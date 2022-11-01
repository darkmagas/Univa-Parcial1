using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;

public class UICurrencyUpdate : MonoBehaviour
{
    [SerializeField] public TMP_Text CurrencyUI;
    [SerializeField] public string currencyName = "Doblon";

    public void IncreaseCurrency(int _currency)
    {
        CurrencyUI.SetText($"{_currency} {currencyName}");
    }
}
