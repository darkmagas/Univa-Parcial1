using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{

   [SerializeField]private int _health = 100;
    private int _courrentHealth = 100;
    [SerializeField] private UnityEvent<float> _onHealthChanged = new UnityEvent<float>();

    // Start is called before the first frame update
    void Start()
    {

        _courrentHealth = _health;
        
    }

    // Update is called once per frame
    public void ReciveDamage(int damage)
    {

        _courrentHealth -= damage;
        _onHealthChanged?.Invoke((float)_courrentHealth / _courrentHealth);

    }
}
