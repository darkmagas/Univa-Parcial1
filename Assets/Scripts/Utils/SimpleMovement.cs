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
        //if(Input.GetKey(KeyCode.W))
        //{
        //    transform.position = new Vector3(transform.position.x, transform.position.y+1*Time.deltaTime, 0);
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    transform.position = new Vector3(transform.position.x+1*Time.deltaTime, transform.position.y, 0);
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    transform.position = new Vector3(transform.position.x, transform.position.y-1*Time.deltaTime, 0);
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    transform.position = new Vector3(transform.position.x-1*Time.deltaTime, transform.position.y, 0);
        //}
        transform.Translate(x:Input.GetAxis("Horizontal")*1*Time.deltaTime, y:Input.GetAxis("Vertical")*1*Time.deltaTime, z:0);
    }
}
