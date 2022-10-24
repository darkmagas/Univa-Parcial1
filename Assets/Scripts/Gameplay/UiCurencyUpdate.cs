using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiCurencyUpdate : MonoBehaviour
{

    [SerializeField] private TMP_Text _Text;
    [SerializeField] private string _currencyName = "Gil";
    public void UpdateCurrency(int currency)
    {
        _Text.SetText($"{currency}{_currencyName}");
        
    }
}
