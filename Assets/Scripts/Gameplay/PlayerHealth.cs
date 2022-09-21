using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int damage;

    public int vidaJugador;
    public Slider BarraVida;



    private void Update()
    {
        BarraVida.value = vidaJugador;

        if(Input.GetKeyDown(KeyCode.E))
        {
            vidaJugador -= damage;
        }
    }
}
