using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int _health = 100;
    private int _currentHealth = 100;
    [SerializeField] private UnityEvent<float> _onHealthChanged = new UnityEvent<float>();

    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = _health; 
    }

    public void ReceiveDamage (int Damage)
    {
        //_currentHealth = _currentHealth - Damage; 
        _currentHealth -= Damage;
    }
}
