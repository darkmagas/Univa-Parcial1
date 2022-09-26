using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] [Range(0, 6)] private float _gameSpeed = 1f;

    void Update()
    {
        Time.timeScale = _gameSpeed;
    }
}
