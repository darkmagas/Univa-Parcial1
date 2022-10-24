using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UICurrencyUpdate : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TMP_Text _text;
    [SerializeField] private string _currencyName = "Gil";


    public void UpdateCurrency(int currency)
    {
        // 20 Gil
        _text.SetText($"{currency} {_currencyName}");
        //Gil 20
        // _text.SetText($"{_currencyName} {currency} ");
    }
}
