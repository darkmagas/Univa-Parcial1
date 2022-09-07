using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class codigo : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * 5, y: 0, z: Input.GetAxis("Vertical") * Time.deltaTime * 5);
    }
}
