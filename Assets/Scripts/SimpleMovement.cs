using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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
        //    transform.position = new Vector3(transform.position.x, transform.position.y + 1 * Time.deltaTime, 0);
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    transform.position = new Vector3(transform.position.x + 1 * Time.deltaTime, transform.position.y, 0);
        //}

        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * 7, 0, Input.GetAxis("Vertical") * Time.deltaTime * 7);

        //if(Input.GetKeyDown(KeyCode.LeftShift))
        //        {
        //    transform.position = new Vector3(transform.position.x + 15 * Time.deltaTime, transform.position.y, transform.position.y);
        //}
    }
}
