using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;

public class UICurrencyUpdate : MonoBehaviour
{
    public TMP_Text CurrencyUI;
    public string Name = "Doblon";

    public void IncreaseCurrency(int amount)
    {
        CurrencyUI.SetText($"{amount} {Name}");
    }
}
