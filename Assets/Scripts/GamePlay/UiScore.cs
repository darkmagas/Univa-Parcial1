using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiScore : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private string _scoreString = "Puntos";

    public void onScoreChange(int val)
    {
        _scoreText.SetText($"{_scoreString} {val:00000}");
    }
    


}
