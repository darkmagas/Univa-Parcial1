using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
        public static GameManager Instance
    {
        get
        { if (_instance ==null)
            {
                var obj= FindObjectOfType<GameManager>();
                if(obj != null)
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
    [SerializeField] [Range(0, 6)] private float   timeStep = 1f;

    private LevelCurrencyManagger _levelCurrencyManagger;

    //private void Update()
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
}
