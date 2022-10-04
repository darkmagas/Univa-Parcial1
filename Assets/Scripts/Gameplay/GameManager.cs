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
            if(_instance == null)
            {
                var obj = FindObjectOfType<GameManager>();
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
    //este codigo sera para cambiar el tiempo si más rapido o más lento del videojuego

    [SerializeField] [Range(0,6)] private float _timeStep = 1; //Ranger va a modificar un numero del cero  a ser dependiendo el numero que escribas

    public void ChangeSpeed(float speed)
    {
        _timeStep= speed;
        Time.timeScale = _timeStep; 
    }
}
