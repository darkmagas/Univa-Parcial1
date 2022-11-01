using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class LevelCurrencyManager : MonoBehaviour
{
    [SerializeField] private int _currencyToAdd = 5;
    [SerializeField] private float _tickRate = 2f;
    private int _currency = 0;
    [SerializeField] private UnityEvent<int> _onCurrencyChanged;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AddCurrency());
    }
    private IEnumerator AddCurrency()
    {
        currency += currencyToAdd;
        onCurrencyChanged?.Invoke(currency);
        yield return new WaitForSeconds(_tickRate);
        StartCoroutine(AddCurrency());
    }
    public bool TrySpendCurrency(int amount)
    {
        if (_currency >= amount)
        {
            _currency -= amount;
            onCurrencyChanged?.Invoke(currency);
            return true;
        }
        return false;
    }
}