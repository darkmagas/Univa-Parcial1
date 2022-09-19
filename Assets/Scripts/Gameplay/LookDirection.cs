using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookDirection : MonoBehaviour
{
    private Vector3 _lastPosition = Vector3.zero;

    void Start()
    {
        //_lastPosition = transform.position;
    }


    void Update()
    {
        // var direction:Vector3 = transform.position - _lastPosition;

        // var targetDirection:Vector3 = Vector3.RotateTowards(current: transform.forward, target: direction, maxRadiantDelta: 30, maxMagnitudeDelta: Time.deltaTime);

        // transform.rotation = Quartenion.RotateTowards(from: transform.rotation, to: Quartenion.lookRotation(targetDirection), maxDegreesDelta: Time.deltaTime);

        //    _lastPosition = transform.position;
    }
}
