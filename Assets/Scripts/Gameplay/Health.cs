using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; //para poder utilizar eventos.

public class Health : MonoBehaviour
{
    [SerializeField] private int _health = 100; //el serialize nos permite modificarlo desde unity.
    private int _currentHealth = 100;
    [SerializeField] private UnityEvent<float> _onHeatlthChanged = new(); //Lo que nos intereza es mandar el porcentaje de vida que va a tener nuestro enemigo. Para cuando la vida cambia


    void Start()
    {
        _currentHealth = _health; //por si hay alguna modificacion en la salud se iguale. 
    }

    public void ReciveDamage(int damage)
    {
        _currentHealth -= damage; //es un chort cut de "_currentHealth - damage" y asi obtener el restante de vida.
        _onHeatlthChanged?.Invoke((float)_currentHealth / _currentHealth); // "?" es para ver si existe el pastel, de ser el caso se invoca el metodo, de lo contrario no se invoca. 
    }
}