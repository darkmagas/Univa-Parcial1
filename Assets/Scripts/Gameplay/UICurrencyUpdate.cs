using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UICurrencyUpdate : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private string _currencyName = "Lotos";
    
    public void UpdateCurrency(int currency)
    {
        // 20 Lotos
        _text.SetText($"{currency} {_currencyName}");
    }
}
