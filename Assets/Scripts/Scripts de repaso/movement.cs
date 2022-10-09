using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * 5, Input.GetAxis("Vertical") * Time.deltaTime * 5, 0);
        
    }
}

//explicación
//abrimos la linea indicando que queremos transformar la posición de un objeto (transform.Translate)
//aqui le estás ordenando que agarre el Input de el axis horizontal que son las flechas de derecha e izquierda(Input.GetAxis(Horizontal))
// y que lo multiplique por la duración del ultimo frame, esto para dar el movimiento (* Time.deltatime)
//despues se multiplica por una velocidad, esto hara qeu se mueva más rapido o lento (* 5)
//se hace lo mismo pero con el eje Vertical (Input.GetAxis("Vertical") * Time.deltaTime * 5)
// como nuestro movimiento es en 2D, se le indica que la z no se movera (, 0)
//
