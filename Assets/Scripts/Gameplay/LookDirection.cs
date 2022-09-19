using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookDirection : MonoBehaviour
{
    private Vector3 _lastPosition = Vector3.zero;

   [SerializeField] private float _rotationSpeed = 150;
    // Start is called before the first frame update
    void Start()
    {
        _lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var direction = transform.position - _lastPosition; //para borrar la ultima direccion a la que se volteó

        var targetDirection = Vector3.RotateTowards(transform.forward, direction, 30, Time.deltaTime);


        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(targetDirection), Time.deltaTime*_rotationSpeed);

        _lastPosition = transform.position;
    }
}
