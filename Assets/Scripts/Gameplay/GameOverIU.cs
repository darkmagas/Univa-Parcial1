using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverIU : MonoBehaviour
{
    [SerializeField] private RectTransform _gameOverPanel;
  
    public void OnGameOver()
    {
        _gameOverPanel.gameObject.SetActive(true);
        GameManager.instance.ChangeSpeed(0);
    }
    
    public void OnRestart()
    {
        GameManager.instance.ChangeSpeed(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
