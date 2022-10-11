using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //transform.position = new vector3
    }

    // Update is called once per frame
    void Update()
    {
        //if (imut.getkey(keycode.w));
        //{
        // transform.position = new vector3 (transforma.position.x , y: transform.position.y+1*time.deltatime, z:0);

        transform.Translate(x: Input.GetAxis("Horizontal") * 1 * Time.deltaTime, y: Input.GetAxis("Vertical") * 1 * Time.deltaTime, z: 0);
    }
}
