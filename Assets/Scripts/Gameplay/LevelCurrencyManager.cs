using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelCurrencyManager : MonoBehaviour
{
    [SerializeField] private int _currencyToAdd = 5;
    [SerializeField] private float _tickRate = 2f;
    private int _currency = 0;
    [SerializeField] private UnityEvent<int> _onCurrenvyChanged;

    void Start()
    {
        GameManager.instance.AddLevelCurrencyManager(this);
       StartCoroutine(AddCurrency());
    }

    // Update is called once per frame
    private IEnumerator AddCurrency()
    {
        _currency += _currencyToAdd;
        _onCurrenvyChanged?.Invoke(_currency);
        yield return new WaitForSeconds(_tickRate);
            StartCoroutine(AddCurrency());

    }

    public bool TrySpendCurrency(int amount) 
    { 
       if(_currency >= amount) 
        {
            _currency -= amount;

            _onCurrenvyChanged?.Invoke(_currency);
            return true; 
        }

        return false;
    }
}
