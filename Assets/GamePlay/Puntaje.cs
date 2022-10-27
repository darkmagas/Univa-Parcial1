using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Puntaje : MonoBehaviour
{
    private float puntaje;

    private TextMeshProUGUI textMesh;

    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        puntaje += Time.deltaTime;
        textMesh.text = puntaje.ToString("0");
    }

    public void SumarPuntos(float puntosEntrada)
    {
        puntaje += puntosEntrada;
    }

}
