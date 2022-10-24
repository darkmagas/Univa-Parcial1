using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICurrencyUpdate : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private string _currencyName = "Gil";

    public void UpdateCurrency(int currency)
    {
        _text.SetText($"{currency} {_currencyName}");
        _text.SetText($"{_currencyName} {currency}"); 
    }
}
