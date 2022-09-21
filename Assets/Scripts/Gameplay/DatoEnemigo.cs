using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DatoEnemigo : MonoBehaviour
{
    public int damage;
    
    public int vidaEnemy;

    public Slider BarraVida;




    private void Update()
    {
        BarraVida.value = vidaEnemy;
    }

}
