using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal")*1*Time.deltaTime,
            Input.GetAxis("Vertical")*1*Time.deltaTime,0);
    }
}
