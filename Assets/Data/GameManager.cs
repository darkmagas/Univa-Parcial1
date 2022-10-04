using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public static GameManager _instance;
    
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
                    GameObject newSingleton = new GameObject(name: "GameManager");
                    _instance = newSingleton.AddComponent<GameManager>();
                }
            }
            return _instance;
        } 
    }


    [SerializeField][Range(0,6)]private float _gameSpeed= 1;

    public void ChangeSpeed(float speed)

    {
        _gameSpeed = speed;
        Time.timeScale = _gameSpeed;
    }
}
