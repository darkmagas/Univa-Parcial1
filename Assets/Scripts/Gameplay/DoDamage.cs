using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDamage : MonoBehaviour
{
    [SerializeField] private int _damage = 10; 
    private void OnTriggerEnter(Collider other)
    {
        //untriger stay es muy ineficiente. evitarlo porque actualiza todo el tiempo.

        if (other.GetComponent<Health>() != null) // "!" para invertir su valor. -cuando no sea igual a-
        {
            other.GetComponent<Health>().ReciveDamage(_damage); //"other" porque asi se puso en el programa. Para que en el caso de que sea nullo se ejecute el daño
        }

    }
}
