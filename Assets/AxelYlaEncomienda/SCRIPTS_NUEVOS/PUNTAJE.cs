using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PUNTAJE : MonoBehaviour
{
    private float puntos;

    private TextMeshProUGUI textMeesh;

    private void Start()
    {
        textMeesh = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        puntos += Time.deltaTime;
        textMeesh.text = puntos.ToString("0");
    }

    public void SumarPuntos(float puntosEntrada) {
    }
}
