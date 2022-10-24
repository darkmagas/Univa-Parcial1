using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICurrencyUpdate : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    public void UpdateCurrency(int currency)
    {
        _text.setText(sourceText: $"{currency} {_currencyName}");
    }
}
