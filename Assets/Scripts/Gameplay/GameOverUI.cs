using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{ 
    [SerializeField] private RectTransform _gameOverPanel;
    public void OnGameOver()
    {
        _gameOverPanel.gameObject.SetActive(true);
        GameManager.Instance.changeSpeed(0);
    }
    public void OnRestart()
    {
        GameManager.Instance.changeSpeed(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    
    
        
    }

