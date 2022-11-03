using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        { if (_instance == null)
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
    [SerializeField] [Range(0, 6)] private float timeStep = 1f;

    private int _enemyCount = 0;

    public int EnemyCount => _enemyCount;

    private LevelCurrencyManagger _levelCurrencyManagger;
    private ScoreManager _scoreManager;

    public void AddscoreManager (ScoreManager scoreManager)
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

   
    public void ChangeSpeed (float speed)
        
    {
        timeStep = speed;
        Time.timeScale = timeStep;
    }

    public void AddLevelCurrencyManagger(LevelCurrencyManagger levelCurrencyManagger)
    {
        _levelCurrencyManagger = levelCurrencyManagger;
    }

    public bool TrySpendCurrency (int amount)
    {
        return _levelCurrencyManagger.TrySpendCurrency(amount);
    }

    public void AddCurrency(int val)
    {
        _levelCurrencyManagger.AddCurrency(val);
    }
}
