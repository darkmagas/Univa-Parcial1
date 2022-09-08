using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
       
  
    }

    // Update is called once per frame
    void Update()
    {
        ////if (Input.GetKey(KeyCode.W))
        ////{
        ////    transform.position = new Vector3(0, transform.position.y * Time.deltaTime, 0);
        ////}

        ////if (Input.GetKey(KeyCode.D))
        ////{
        ////    transform.position = new Vector3(transform.position.x * Time.deltaTime, 0, 0);
        ////}
        ////Debug.Log("dada");

        transform.Translate(Input.GetAxis("Horizontal") * 1 * Time.deltaTime, Input.GetAxis("Vertical") * 1 * Time.deltaTime, 0);
    }
}
