using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{

    public float vida = 100;
    public Image barraDeVida;

    // Update is called once per frame
    void Update()
    {

        Mathf.Clamp(vida, 0, 100);
        barraDeVida.fillAmount = vida / 100;

    }
}
