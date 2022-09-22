using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
public class Barradevida1 : MonoBehaviour
{

    public Image barradeVida;

    public float vidaActual;

    public float vidaMaxima;

    void Update()
    {
        barradeVida.fillAmount = vidaActual / vidaMaxima; 
    }
}
