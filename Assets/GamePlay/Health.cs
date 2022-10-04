using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Health : MonoBehaviour {



    [SerializeField] private int _health = 100;


    private int _currentHealth = 100;

    [SerializeField] private UnityEvent<float> onHealthChange = new ();
    [SerializeField] private UnityEvent _onDeath= new ();

    // Start is called before the first frame update
    //void Start()
    void OnEnable() //reusar cuantas veces queramos

    {
        _currentHealth = _health;


    }
    public void ReciveDamage(int damage)
    {
       
        
        _currentHealth -= damage;
        if (_currentHealth < 0)
            _currentHealth = 0;

        onHealthChange?.Invoke((float)_currentHealth / _health);
        if (_currentHealth == 0)
            _onDeath?.Invoke();

    }
}

