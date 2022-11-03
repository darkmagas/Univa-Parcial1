using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelCurrencyManager : MonoBehaviour
{
    [SerializeField] private int _currencyToAdd = 5;
    [SerializeField] private float _tickRate = 2f;
    private int _curency = 0;
    [SerializeField] private UnityEvent<int> _onCurrencychanged;
    void Start()
    {
        GameManager.Instance.AddLevelCurrencyManager(this); //lo añadimos despues del script en game manager para que se inicie con el 
                                                           //currency correspondiente al nivel
        StartCoroutine(AddCurrency());
    }
    public void AddCurrency(int val)//*x2
    {
        _curency += val;
        _onCurrencychanged?.Invoke(_curency);
    }

   private IEnumerator AddCurrency()
    {
        _curency += _currencyToAdd;
        _onCurrencychanged?.Invoke(_curency);
        yield return new WaitForSeconds(_tickRate);
        StartCoroutine(AddCurrency());
    }

    public bool TrySpendCurrency(int amount)
    {
        if (_curency >= amount)
        {
            _curency -= amount;
            _onCurrencychanged?.Invoke(_curency);
            return true;
        }
        return false;
    }
}

