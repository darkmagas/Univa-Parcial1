using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class LevelCurrencyManager : MonoBehaviour
{
    [SerializeField] private int _currencyToAdd = 5;
    [SerializeField] private float _TickRate = 2f;
    private int _currency = 0;
    [SerializeField] private UnityEvent<int> _onCurrencyChanged;

    // Start is called before the first frame update
    void Start()
    {
       
        StartCoroutine(AddCurrency());
        
    }
        private IEnumerator AddCurrency()
    {
        _currency += _currencyToAdd;
        _onCurrencyChanged?.Invoke(_currency);
        yield return new WaitForSeconds(_TickRate);
        StartCoroutine(routine: AddCurrency());

        
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
