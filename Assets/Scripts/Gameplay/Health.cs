using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{

    [SerializeField]private int _health = 100;
    private int _currentHealth = 100;
    [SerializeField]private UnityEvent<float> _onHealthChanged = new UnityEvent<float>();
    [SerializeField] private UnityEvent _onDeath = new ();

    // Start is called before the first frame update
    void OnEnable()
    {
        _currentHealth = _health;   
    }
    

    public void ReceiveDamage(int damage)
    {
        //_currentHealth = _currentHealth - damage
        _currentHealth -= damage; 
        if (_currentHealth < 0)
        {
            _currentHealth = 0;  //esto se usa para qeu nuestra vida nunca baje de 0
        }
        _onHealthChanged?.Invoke((float)_currentHealth/_health);
        //el simbolo de pregunta ? es para preguntarle si ya tiene esa acción para qeu realice el codigo
        if (_currentHealth == 0)
            _onDeath?.Invoke();
                

        //trtanform.lookAt
    }
}
