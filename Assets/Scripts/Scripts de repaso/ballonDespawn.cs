using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Magas.Utilities;

public class ballonDespawn : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            EventDispatcher.Dispatch(new DespawnObject(gameObject));
        }
    }
}
//Explicación: 

//OJO para que el codigo funcione debes escribir (using Magas.Utilities;) hasta mero arriba donde se encuentran los using
//IMPORTANTE para qeu este codigo funcione, al objeto que le pongamos el codigo en el inspector buscamos donde tenga su Collider y activamos la casilla de "Is trigger"
//REQUISITO debe haber otro objeto con una tag de "player" (explicado en el punto 7.2)

// 1.- aquí se creará un evento para que cuando el portador del codigo choque con el collider de otro objeto, el portador del codigo desaparezca

// 2.- comenzamos llamando una acción privada que solo afectará a quien porte el codigo (private void)
// 3.- luego le indicamos que el codigo será usado cunado se entre a algo (OnTriggerEnter)
// 4.-luego le estaremos indicando entre parentesis que estaremos usando al collider y al otro objeto (Collider other)
// 5.- abrimos corchetes {} y comenzamos a indicar un "if"
// 6.- dentro del if le diremos que revise si la tag del otro objeto es una tag de "player" (other.gameObject.CompareTag("Player"))
// 7.- esto se puede entender como "other = el otro objeto", "game object = que revise dentro de las propiedades del otro objeto", "CompareTag("Player") = que revise si su tag es de player"
// 7.2.- * las tag´s se ponen dentro de unity a los objetos en el menú casi hasta arriba, sirven como etiquetas para distinguir que es que*
//
// 8.- luego se indica dentro de corchetes {} que es lo que sucederá si en efecto, el otro objeto tiene tag de Player
// 9.- comenzamos diciendole que hará un evento/acción (EventDispatcher.Dispatch)
// 10.- y dentro de parentesis le indicamos lo que queremos que sea ese evento (new DespawnObject (gameObject));
// 11.- esto se puede entender como que le indicas que realize un evento donde se elimine el objeto que porta el codigo "new = indica que es una acción nueva", "DespawnObject = indica que algo será borrado/despawneado", "(gameObject) = le dice que lo que quiere qeu despawné, sea el mismo game object, osea el objeto que tiene el codigo"
