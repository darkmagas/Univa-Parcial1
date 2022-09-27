using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SimpleMovement : MonoBehaviour
{
    [SerializeField] public float speed = 10;
    [SerializeField] public float jump;
     
    void Start()
    {


        



    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, Input.GetAxis("Vertical") * speed * Time.deltaTime,0);
        jump = 0;
if (Input.GetButtonDown("Jump")) 
        {
            transform.position += new Vector3(0, 0, 5);
        }



        //if (Input.GetKey(KeyCode.W))
        //{
        //    transform.position = new Vector3(transform.position.x, transform.position.y + 1 *Time.deltaTime, 0);


        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    transform.position = new Vector3(transform.position.x + 1 * Time.deltaTime, transform.position.y, 0);


        //}

    }
}
