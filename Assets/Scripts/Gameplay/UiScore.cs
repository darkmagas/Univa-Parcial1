using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiScore : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private string _scoreString = "Puntos :";

    public void OnScoreChange(int val)
        {
        Debug.Log("Score change");
         _scoreText.SetText($"{_scoreString} {val:00000}");
        }
}
