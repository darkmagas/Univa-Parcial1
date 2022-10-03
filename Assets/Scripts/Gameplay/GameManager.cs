using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    private static GameManager _instance;  //static =  que siempre existe.  instance = UNa variable de la CLASE
    public static GameManager Instance
    {
        get
        {
            if(_instance == null)  //este codigo de la linea 13 a la 24 sirve para verificar qeu siempre haya un game manager en la escena
            {
                var obj = FindObjectOfType<GameManager>();
                if(obj != null)
                {
                    _instance = obj;
                }
                else // si no hay un GameManager aqui se ordena en crearlo 
                {
                    GameObject newSingleton = new GameObject("GameManager");
                    _instance = newSingleton.AddComponent<GameManager>();
                }
            }
            return _instance;
        }
    }
    [SerializeField] [Range(0,6)]private float _gameSpeed = 1f;
  
    // Update is called once per frame
    public void ChangeSpeed(float speed)
    {
        _gameSpeed = speed;
        Time.timeScale = _gameSpeed;
    }
}
