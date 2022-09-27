using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField][Range(0,6)]private float timeStep = 1f; //para controlar la velocidad del juego y dar pausa.
                                                             //serialized para modificar desde unity
                                                             //range para establecer un rango, igual se ve en unity
    private void Update()
    {
        Time.timeScale = timeStep;
    }
}
