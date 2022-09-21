using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour {
   
    public Slider _slider;

    [SerializeField]private int _health = 100;

    private int _currentHealth = 100;

    [SerializeField] private UnityEvent<float> onHealthChange = new ();

    // Start is called before the first frame update
    void Start()

    {
        _currentHealth = _health;


    }
    public void ReciveDamage(int damage)
    {
       
        
        _currentHealth -= damage;
        onHealthChange?.Invoke((float)_currentHealth / _health);

    }
}

