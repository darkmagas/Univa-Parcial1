using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  [SerializeField] [Range(0,6)] private float _gamespeed = 1f;
    void Start()
    {
        Time.timeScale = _gamespeed;
    }

    
    void Update()
    {
        
    }
}
