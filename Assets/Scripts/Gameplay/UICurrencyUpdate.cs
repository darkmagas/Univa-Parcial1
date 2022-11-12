using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UICurrencyUpdate : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private string _currencyName = "Gil";

    public void UpdateCurrency(int _currency)
    {
        // 20 Gil
        _text.SetText($"{_currency} {_currencyName}");
    }
}
