using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    
    
    [SerializeField]private int _health = 100;

<<<<<<< Updated upstream

        private int _currentHealth = 100;

    [SerializeField] private UnityEvent<float> _onHealthChanged = new ();
     


    
    void Start()
=======
    private int _currentHealth = 100;
    [SerializeField]private UnityEvent<float> _onHealthChanged = new ();
    [SerializeField]private UnityEvent _onDeath = new ();

    void OnEnable()
>>>>>>> Stashed changes
    {

    _currentHealth = _health;

    }

    public void ReceiveDamage(int damage)
<<<<<<< Updated upstream
{
    _currentHealth -= damage;
    _onHealthChanged?.Invoke((float)_currentHealth / _health);
=======
    {
        //_currentHealth = _currentHealth - damage;
        _currentHealth -= damage;
        if (_currentHealth < 0)
        {
            _currentHealth = 0;
        }
        _onHealthChanged?.Invoke((float)_currentHealth / _health);
        if (_currentHealth == 0)
            _onDeath.Invoke();

    }
>>>>>>> Stashed changes
}
}

