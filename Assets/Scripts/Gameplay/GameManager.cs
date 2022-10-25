using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance; //creamos variable global, pertenece a la clase no a ningun objeto

    public static GameManager Instance { //*
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
                    GameObject newSingleton = new GameObject("GameManager"); //singleton es basica y facil, no muy recomendable
                    _instance = newSingleton.AddComponent<GameManager>();
;                }
            }
            return _instance;
    }
    }
    [SerializeField][Range(0,6)]private float _timeStep = 1f; //para controlar la velocidad del juego y dar pausa.
                                                              //serialized para modificar desde unity
                                                              //range para establecer un rango, igual se ve en unity
                                                              // private void Update()
                                                              //{ Time.timeScale = timeStep;} *esto lo cambiamos por el de abajo
    private LevelCurrencyManager _levelCurrencyManager; //*Lo añadimos al game manager para no pnerlo en cada script
    public void timeStep(float speed)
    {
        _timeStep = speed;
        Time.timeScale = _timeStep;
    }
    
    public void AddLevelCurrencyManager(LevelCurrencyManager levelCurrencyManager) //*para el puntuacion hasta mrir
    {
        _levelCurrencyManager = levelCurrencyManager;
    }

    public bool TrySpendCurrency(int amount) //*puntuacion hasta morir
    {
        return _levelCurrencyManager.TrySpendCurrency(amount);
    }
}
