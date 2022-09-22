using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //este codigo sera para cambiar el tiempo si más rapido o más lento del videojuego

    [SerializeField] [Range(0,6)] private float timeStep = 1; //Ranger va a modificar un numero del cero  a ser dependiendo el numero que escribas

    private void Update ()
    {
        Time.timeScale = timeStep; 
    }
}
