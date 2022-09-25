using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricMovement : MonoBehaviour
{

    [SerializeField] public float speed = 10;
   
    




    void Update()
    {



        transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime);


       
        



    }


}
