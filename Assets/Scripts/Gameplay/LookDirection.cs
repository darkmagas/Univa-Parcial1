using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookDirection : MonoBehaviour
{
    private Vector3 _lastPosition = Vector3.zero;
    [SerializeField] private float _rotationSpeed = 150;  /* [SerializedField]= se pone antes de un private para poder acceder a otro private */
    // Start is called before the first frame update
    void Start()
    {
        _lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var direction = transform.position - _lastPosition;  /*Se resta el punto a con el punto b para poder decidir hacia que dirección se estara dirigiendo*/

        var targetDirection = Vector3.RotateTowards(transform.forward, direction, 30, Time.deltaTime); /*esta linea hace que se aline el axis rotando hacia donde debe de voltear a ver(el 30 son grados radiales de cuanto se permite mover)*/

        //IMPORTANTE cada que usemos rotacion debemos usar el quaternion para que se mueva en 4 ejes y funcione mejor
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(targetDirection), Time.deltaTime*_rotationSpeed);  /* hace que volté a ver a la direccion*/

        _lastPosition = transform.position;


        //al cilindro (nosotros) activarle el "is Trigger" los trigger son cosas qeu ejecutan algo
        //crear un tag que diga "Enemy" en el empty del enemy unity

    }
}
