using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField]private int _health = 100;
    private int _currentHealth = 100;
       [SerializeField] private UnityEvent <float> _onHealthChanged = new UnityEvent<float>();
    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = _health;
        
    }

    public void RecieveDamage(int damage)
    {

        _currentHealth -= damage; //Shortcut para irle restando el Da�o
        _onHealthChanged?.Invoke(arg0: (float)_currentHealth / _health); //la interrogaci�n se asegura de que el objeto exista y pueda ejecutarse
    }
}
