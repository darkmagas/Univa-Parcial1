using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIScore : MonoBehaviour
{
    [SerializeField] private TMP_Text _ScoreText;
    [SerializeField] private string _scoreString = "Puntos :";

    public void OnScoreChange(int val)
    {
        _ScoreText.SetText(sourceText: $"{_scoreString} {val:00000}");
    }

}
