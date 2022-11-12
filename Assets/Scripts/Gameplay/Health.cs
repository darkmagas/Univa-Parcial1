using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField]private int _health = 100;
    private int _currentHealth = 100;
    [SerializeField] private UnityEvent <float> _onHealthChanged = new UnityEvent<float>();
    [SerializeField]private UnityEvent _onDeath = new();
    public Text healthText;
    // Start is called before the first frame update
    void OnEnable() //OnEnable se ejecuta cada vez que lo prendemos
    {
        _currentHealth = _health;
        
    }

    public void ReceiveDamage(int damage)
    {

        _currentHealth -= damage; //Shortcut para irle restando el Daño
      healthText.text = "" + _currentHealth + "%";

        if (_currentHealth < 0)
        {
            _currentHealth = 0;
        }

        _onHealthChanged?.Invoke(arg0: (float)_currentHealth / _health); //la interrogación se asegura de que el objeto exista y pueda ejecutarse
        if (_currentHealth == 0)
            _onDeath?.Invoke();
    }
}
