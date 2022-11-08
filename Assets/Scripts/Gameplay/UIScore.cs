using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIScore : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private string _scoreString = "Puntos : ";

    public void OnScoreChange(int val)
    {
        //Puntos : 00020 
        _scoreText.SetText($"{_scoreString} {val:00000}");
    }
}
