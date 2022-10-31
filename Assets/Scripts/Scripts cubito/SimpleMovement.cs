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
        transform.Translate(x: Input.GetAxis("Horizontal") * Time.deltaTime * 5,
            y: Input.GetAxis("Vertical") * Time.deltaTime * 5, z: 0);
    }
}


    ///if (Input.GetKey(KeyCode.W))
       /// {
       ///     transform.position = new Vector3(transform.position.x, y: transform.position.y+1*Time.deltaTime , z:0);
      ////  }
   ////     if (Input.GetKey(KeyCode.D))
   ////     {
     ////       transform.position = new Vector3(x: transform.position.x + 1 * Time.deltaTime, transform.position.y, z: 0);
     ////   }