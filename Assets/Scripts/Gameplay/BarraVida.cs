using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    public int damage;
    public int vidaEnemigo;
    public Slider BarraVidaEnamigo;


    private void Update()
    {
        BarraVidaEnamigo.value = vidaEnemigo;

        if (Input.GetKeyDown(KeyCode.E))
        {
            vidaEnemigo -= damage;
        }
    }

}
