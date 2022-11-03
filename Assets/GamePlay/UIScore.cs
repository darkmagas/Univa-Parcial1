using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIScore : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private string _scoreString;

    public void OnScoreChange(int val)
    {
        //puntos : 0000020 (para que salgan los ceros antes de la cantidad)
        _scoreText.SetText($"{_scoreString} {val:00000}");
    }
}
