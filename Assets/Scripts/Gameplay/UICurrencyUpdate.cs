using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UICurrencyUpdate : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private string _currencyName = "Coins";

    public void UpdateCurrency(int currency)
    {   // $ sirve para indicar que hay variables dentro de una cadena de texto.
        _text.SetText($"{currency} {_currencyName}");
    }
}
