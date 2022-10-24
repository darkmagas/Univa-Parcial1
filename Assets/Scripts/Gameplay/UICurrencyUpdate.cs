using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UICurrencyUpdate : MonoBehaviour
{
    [SerializeField] private TMP_Text _Text;
    [SerializeField] private string _currencyName = "Gil";

    public void updateCurrency(int currency)
    {
        _Text.SetText($"{currency}  {_currencyName}");

        
    }

}
