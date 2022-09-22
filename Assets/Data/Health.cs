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

    public Slider BarraVida;

    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = _health;

    }
    public void ReceiveDamange(int damage)

    {
            _currentHealth -= damage;
            _onHealthChanged?.Invoke(arg0: (float)_currentHealth / _health);
        BarraVida.value = _currentHealth;
    }
}
  
