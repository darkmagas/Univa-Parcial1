using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiTurretCurrency : MonoBehaviour
{
   [SerializeField] private TMP_Text _text;
        [SerializeField] private string _currencyName = "Mana";

        public void UpdateCurrency(int currency)
    {
        // 20 Gil
        _text.SetText($"{currency} {_currencyName}");
    }
}
