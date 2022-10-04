using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DatoEnemigo : MonoBehaviour
{
    public int damage;
    public int vidaEnemigo;
    public Slider BarraVidaEnemigo;

    private void Update()
    {
        BarraVidaEnemigo.value = vidaEnemigo;
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            vidaEnemigo -= damage;
        }
    }
}
