using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class BarLife : MonoBehaviour
{
    private int _currentHealth = 100;
    public Slider barraVida;
  
    void Update()
    {
        barraVida.value = _currentHealth;
    }
}
