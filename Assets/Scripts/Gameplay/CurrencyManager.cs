using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CurrencyManager : MonoBehaviour
{
    [SerializeField] private int _currencyToAdd = 5;
    [SerializeField] private float _tickRate = 2f;
    [SerializeField] private UnityEvent<int> _onCurrencyChanged;
    private int _currency = 0;


    private void Start()
    {
        GameManager.Instance.addCurrencyManager(this);
        StartCoroutine(AddCurrency());

    }

    private IEnumerator AddCurrency()
    {
        _currency += _currencyToAdd;
        _onCurrencyChanged?.Invoke(_currency);
        yield return new WaitForSeconds(_tickRate);
        StartCoroutine(AddCurrency());
    }
    
    public bool TrySpendCurrency(int amount)
    {
        if (_currency >= amount)
        {
            _currency -= amount;
            _onCurrencyChanged?.Invoke(_currency);
            return true;

        }
        return false;

    }
    
        
        
        

}



