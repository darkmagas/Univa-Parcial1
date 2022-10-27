using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Magas.Utilities;
public class ContadorPuntaje : MonoBehaviour
{
    private float monedas;
    private TextMeshProUGUI textMesh;
    [SerializeField] private string _Name;

    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
       textMesh.text = GetComponent<LevelCurrencyManager>.AddCurrrency(_currency);
    }
}
