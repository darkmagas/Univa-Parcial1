using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    float speed = 5f;


    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, vertical);

        movementDirection.Normalize();

        transform.position = transform.position + movementDirection * speed * Time.deltaTime;
    }
}
