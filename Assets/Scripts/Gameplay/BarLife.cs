using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class BarLife : MonoBehaviour
{
    private int _currentHealth;
    public Slider barraVida;
  
     private void Update()
    {
        barraVida.value = _currentHealth;
        
        //barraVida.value = Health;
    }
}
