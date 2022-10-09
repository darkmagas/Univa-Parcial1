using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDamage : MonoBehaviour
{
    public int damage = 1;
     private void OnTriggerEnter(Collider other)
    {
            if (other.GetComponent<Health>() != null)
            {
            var otherHealth = other.GetComponent<Health>();
            otherHealth.ReceiveDamage(damage);
            }
    }
}
//Explicación:


// 1.- aquí se genera un comando que servirá para hacer daño y desaparecer cuando se haga daño
//
// 2.- comenzamos con el daño que se hará declarando una cantidad publica, esto para que otros codigos puedan acceder a ella, que guarde un numero de daño (public int = 1;)
// 3.-  los int son almacenes de numeros y le estamos indicando que (int = 1) osea que almacene una unidad, este será el numero de daño que se hará
// 4.- luego creamos una variable privada para que solo afecte a lo que le pongamos el codigo (private void)
// 5.- El (OnTriggerEnter) nos indica que este será un codigo diseñado para cuando algo entra en algun objeto externo 
// 6.- seguido de esto, entre un parentesis declaramos que estaremos interactuando con un collider (Collider)
// 7.- de igual forma estaremos interactuando con el objeto mismo asi que se agrega dentro del parentesis (Collider other)
//
// 8.- dentro escribimos una variable de "if" y le pedimos que revise la vida del otro objeto (other.GetComponent<Health>)
// 9.- justo despúes se pone el (!= null) el signo de exclamasión(!) junto con el igual(=) significa "no es igual a.."
// 10.- es decir que toda esta linea ( if (other.GetComponent<Health>() != null)) sirve para obtener el numero de vida del otro objeto y comprobar que no sea nulla la vida(osea que si tenga algo de vida), si si tiene algo de vida se realizarán las siguientes acciones
//
// 11.-dentro del if colocamos corchetes {}, y dentro creamos una variable que se llame other health, (var otherhealth)y le decimos que dentro de esa variable almacene la informacion de la vida del otro objeto (other.GetComponent<Health>())
// 11.2.- * la variable se crea con la finalidad de crear un "shortcut" en el codigo, cuando necesitemos hacer algo con la vida del otro objeto solo llamamos la variable que ya tendrá la vida registrada en lugar de tener que volverla a llamar*
// 12.- así que mandamos a llamar a la variable y la vinculamos con la varíable que recibe daño de la vida del otro objeto y que afecte a su cantidad de damage (otherhealth.ReceiveDamage(damage))

