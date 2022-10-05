using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float _health;
    public float _maxhealth;
    public GameObject _healthBarUI;
    public Slider slider;

    void start()
    {
        _health = _maxhealth;
        slider.value = CalculateHealth();
    }

    private void Update()
    {
        slider.value = CalculateHealth();

        if(_health < _maxhealth)
        {
            _healthBarUI.SetActive(true);
        }
        
        if(_health <= 0)
        {
            Destroy(gameObject);
        }

        if (_health > _maxhealth)
        {
            _health = _maxhealth;
        }

    }

    float CalculateHealth()
    {
        return _health / _maxhealth;
    }

}
