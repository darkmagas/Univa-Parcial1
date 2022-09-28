using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int _health = 100;
    private int _currentHealth = 100;
    [SerializeField] private UnityEvent<float> __onHealthChanged = new UnityEvent<float> ();
    void Start()
    {
        _currentHealth = _health;
    }

    
    public void ReceiveDamage(int damage)
    {
        //_currentHealth =_currentHealth - damage;
        _currentHealth -= damage;
        __onHealthChanged?.Invoke(arg0: (float)_currentHealth / _health);
    }
}
