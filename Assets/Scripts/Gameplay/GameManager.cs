using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance; //static es una variable de la clase y no de un objeto (siempre va a existir, no lo tenemos que llamar(no se necesita un objeto))
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
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
    [SerializeField] [Range(0,6)] private float _gameSpeed = 1f;
    // Start is called before the first frame update

    // Update is called once per frame
   public void ChangeSpeed(float speed)
    {
        _gameSpeed = speed;
        Time.timeScale = _gameSpeed;
    }
}
