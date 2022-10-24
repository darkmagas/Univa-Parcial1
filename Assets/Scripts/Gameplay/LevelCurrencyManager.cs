using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCurrencyManager : MonoBehaviour
{
    [SerializeField] private int _currencyToAdd = 5;
    [SerializeField] private int _tickRate = 2f;
    private int _currency = 0;
  

    
    void Start()
    {
        GameManager.Instance.AddLevelCurrencyManager(this);
        StartCoroutine(AddCurrency());
        
    }

    private IEnumerator AddCurrency()
    {
        _currency += _currencyToAdd;
        yield return new WaitForSeconds(_tickRate);
        StartCoroutine(AddCurrency());
    }

    public bool TrySpendCurrency(int amount)
    {
        if(_currency>= amount)
        { }
        _currency -= amount;
        _onCurrencyChanged?.Invoke(_currency)







    {
        
    }
}
