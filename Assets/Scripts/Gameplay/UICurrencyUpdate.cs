using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UICurrencyUpdate : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private string _currencyName = "monocoin";

    public void UpdateCurrency(int currency)
    {
        _text.SetText($"{currency} {_currencyName}");
        //_text.SetText($"{_currencyName} : {currency}");
    }
}
