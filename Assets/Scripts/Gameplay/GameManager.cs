using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] [Range(0,6)] private float _gameSpeed = 1f;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = _gameSpeed;
    }
}
