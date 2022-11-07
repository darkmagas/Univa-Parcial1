using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance {
        get
        {
            if (_instance == null)
            {
                var obj = FindObjectOfType<GameManager>();
                if (obj != null)
                {
                    _instance = obj;
                }
                else
                {
                    GameObject newSingleton = new GameObject("GameManager");
                    _instance = newSingleton.AddComponent<GameManager>();
                }
            }
            return _instance;
        } 
    }
    [SerializeField] [Range(0,6)] private float _gameSpeed = 1f;
    private int _enemyCount = 0; 
    public int EnemyCount => _enemyCount;
    
    private LevelCurrencyManager _levelCurrencyManager;
    private ScoreManager _scoreManager;

    public void AddScoreManager(ScoreManager scoreManager)
    {
        _scoreManager = scoreManager;
    }

    public void ModifyScore(int value)
    {
        _scoreManager.ModifyScore(value);
    }
    public void AddEnemy(int add)
    {
        _enemyCount += add;
    }
    public void ChangeSpeed(float speed)
    {
        _gameSpeed = speed;
        Time.timeScale = _gameSpeed;
    }
    
    public void AddLevelCurrencyManager(LevelCurrencyManager levelCurrencyManager)
    {
        _levelCurrencyManager = levelCurrencyManager;
    }
    
    public bool TrySpendCurrency(int amount)
    {
        return _levelCurrencyManager.TrySpendCurrency(amount);
    }

    public void AddCurrency(int val)
    {
        _levelCurrencyManager.AddCurrency(val);
    }
    
}
