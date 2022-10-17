using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int _health = 100;
    private int _currentHealt = 100;
    [SerializeField] private UnityEvent<float> _onHealthChanged = new UnityEvent<float>();
    [SerializeField] private UnityEvent _onDeath = new UnityEvent();

    void onAble()
    {

        _currentHealt = _health;

    }

    public void ReciveDamage(int damage)
    {

        _currentHealt -= damage;
        if (_currentHealt < 0)
        {

            _currentHealt = 0;

        }
        _onHealthChanged?.Invoke(arg0: (float)_currentHealt / _health);

        if (_currentHealt == 0)
            _onDeath?.Invoke();

    }

}
