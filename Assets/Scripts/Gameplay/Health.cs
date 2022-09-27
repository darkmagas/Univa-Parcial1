using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField]private int _health = 100;
    private int _currentHealth = 100;
    [SerializeField] private UnityEvent<float> _onHealthChanged = new();
    
    void Start()
    {

        _currentHealth = _health;

    }

    public void ReceiveDamage(int damage) 
    { 
    
        _currentHealth -= damage;
        _onHealthChanged?.Invoke((float)_currentHealth / _health);

    }
}
