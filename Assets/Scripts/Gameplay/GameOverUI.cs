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

    // Update is called once per frame
    public void OnRestart()
    {
        
        GameManager.Instance.ChangeSpeed(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
