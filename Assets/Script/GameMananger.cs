using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMananger : MonoBehaviour
{
    [SerializeField] private float _gameSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = _gameSpeed;
    }
}
