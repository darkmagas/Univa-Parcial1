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

        //if (Input.GetKey(KeyCode.W))
        //{
        //    transform.position = new Vector3(x: transform.position.x, y: transform.position.y +1*Time.deltaTime, z:0);
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    transform.position = new Vector3(x: transform.position.x +1*Time.deltaTime, y: transform.position.y, z:0);
        //}

        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * 5, Input.GetAxis("Vertical") * Time.deltaTime * 5, 0);
    }
       
}

//explicaci�n
//abrimos la linea indicando que queremos transformar la posici�n de un objeto (transform.Translate)
//aqui le est�s ordenando que agarre el Input de el axis horizontal que son las flechas de derecha e izquierda(Input.GetAxis(Horizontal))
// y que lo multiplique por la duraci�n del ultimo frame, esto para dar el movimiento (* Time.deltatime)
//despues se multiplica por una velocidad, esto hara qeu se mueva m�s rapido o lento (* 5)
//se hace lo mismo pero con el eje Vertical (Input.GetAxis("Vertical") * Time.deltaTime * 5)
// como nuestro movimiento es en 2D, se le indica que la z no se movera (, 0)
//
