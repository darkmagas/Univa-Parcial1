using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class GmeOverUi : MonoBehaviour
{
    [SerializeField] private RectTransform _gameOverPanel;
    public void OnGameover()
    {
        _gameOverPanel.gameObject.SetActive(true);
        GameManager.instance.ChangeSpeed(0);

    }

   {

    public void OnRestart()

    {
    
    GameManager
    
    
    }


}