using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
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


    [SerializeField] [Range(0, 6)] private float _timeSpeed = 1f;

    private LevelCurrencyManager _levelCurrencyManager;

    public void ChangeSpeed(float speed)
    {
        _timeSpeed = speed;
        Time.timeScale = _timeSpeed;
    }

    public void AddLevelCurrencyManager(LevelCurrencyManager levelCurrencyManager)
    {
        _levelCurrencyManager = levelCurrencyManager;
    }

    public bool TrySpendCurrency(int amount)
    {
        return _levelCurrencyManager.TrySpendCurrency(amount);
    }
}
