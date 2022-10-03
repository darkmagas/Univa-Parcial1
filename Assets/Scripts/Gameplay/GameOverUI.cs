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
        GameManager.Instance.ChangeSpeed(0);
    }
    public void OnRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GameManager.Instance.ChangeSpeed(1);

    }
}
