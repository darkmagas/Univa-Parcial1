using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

     [SerializeField]private int _health = 100;
    
    private int _currentHealth = 100;
    [SerializeField] private UnityEvent<float> _onHealthChanged = new UnityEvent<float>();
    [SerializeField] private UnityEvent _onDeath = new UnityEvent();

    public Slider BarraVida;

    // Start is called before the first frame update
    void OnEnable()
    {
        _currentHealth = _health;
    }

    public void ReceiveDamange(int damage)

    {
            _currentHealth -= damage;
        if (_currentHealth < 0)
        {
            _currentHealth = 0;
        }

            _onHealthChanged?.Invoke(arg0: (float)_currentHealth / _health);
        if (_currentHealth == 0)
            _onDeath?.Invoke();

        BarraVida.value = _currentHealth;
    }
}
  
