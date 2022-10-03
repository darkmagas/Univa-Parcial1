using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Healt : MonoBehaviour
{
    [SerializeField]private int _healt = 100;
    private int _currentHealth = 100;
   [SerializeField] private UnityEvent<float> _onHealthChanged = new UnityEvent<float>();
    [SerializeField] private UnityEvent
    // Start is called before the first frame update
      void OnEnable()
    {
        _currentHealth = _healt;  
    }
    public void receiveDamage(int damage)
    {
        _currentHealth -= damage;
        if (_currentHealth < 0)
        { 
        _currentHealth = 0;
        }
        _onHealthChanged?.Invoke(arg0:(float)_currentHealth/_healt);
        if (_currentHealth == 0)
            _onDeath?.invoke();

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
