using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCurrencyManager : MonoBehaviour
{
    [SerializeField] private int _currencyToAdd = 5;
    [SerializeField] private float _tickRate = 2f;
    
    
    private int _currency=0;
    [SerializeField] private UnityEvent<int> _onCurrencyChanged;
    
    void Start()
    {
        GameManager.Instance.AddLevelCurrencyManager(this);
        StartCoroutine(AddCurrency());
    }

    private IEnumerator AddCurrency()
    {

        _currency += _currencyToAdd;
        _onCurrencyChanged?.invoke(_currency);
        yield return new WaitForSeconds(_tickRate);
        StartCoroutine(AddCurrency());
    }

    public bool TrySpendCurrency(int amount)
        if(_currency >= amount)
        {
         _currency -= amount ;
         _onCurrencyChanged?.invoke(_currency);      
        }

}

