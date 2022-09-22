using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Barra : MonoBehaviour
{
    public Image barra;

    public float vidaActual;

    public float vidaMaxima;




    void Update()
    {
        barra.fillAmount = vidaActual / vidaMaxima;
    }
}
