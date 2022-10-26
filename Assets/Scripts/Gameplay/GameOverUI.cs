using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private RectTransform _gameObjectPanel;
    
    public void OnGameOver()
    {
        _gameObjectPanel.gameObject.SetActive(true);
        GameManager.Instance.ChangeSpeed(0);
    }
    public void OnRestart()
    {
        GameManager.Instance.ChangeSpeed(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}