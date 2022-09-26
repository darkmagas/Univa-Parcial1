using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookDirection : MonoBehaviour
{
    private Vector3 _lastPosition = Vector3.zero;

    void Start()
    {
        _lastPosition = transform.position;
    }


    void Update()
    {
         var direction = transform.position - _lastPosition;

         var targetDirection = Vector3.RotateTowards(transform.forward,direction, maxRadiantDelta: 30, Time.deltaTime);

         transform.rotation = Quartenion.RotateTowards(transform.rotation,Quartenion.lookRotation(targetDirection),Time.deltaTime);

         _lastPosition = transform.position;
    }
}
