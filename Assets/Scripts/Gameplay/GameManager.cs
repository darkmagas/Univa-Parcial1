using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour

    //este codigo controla la velocidad del juego
{
    ­[SerializeField] [Range(0, 6)] private float timeStep = 1; // este se modifica para controlar el tiempo

    private void Update()
    {
        Time.timeScale = timeStep;
    }
}
