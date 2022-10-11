using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleMovement : MonoBehaviour
{//
    //Start is called before the first frame update
    void Start()
    {

        //transform.position=new Vector3
    }

     //Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.W)) ;
        //    }

        //  Transform.position = new Vector3(Transform.position.x, y: transform.position.y+1*Time.deltaTime, z:0);


        transform.Translate(x: Input.GetAxis("Horizontal") * 1 * Time.deltaTime,
             y: Input.GetAxis("Vertical") * 1 * Time.deltaTime, z: 0);

    
    }
}
