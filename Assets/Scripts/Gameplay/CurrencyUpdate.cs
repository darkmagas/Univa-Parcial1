using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrencyUpdate : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private string _currencyName = "Pesos";

    public void UpdateCurrency(int currency)
    {
        _text.SetText(sourceText: $"{currency}{_currencyName}");
    }

}
