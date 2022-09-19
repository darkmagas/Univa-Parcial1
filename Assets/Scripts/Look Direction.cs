using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookDirection : MonoBehaviour
{
    private Vector3 _lastPosition=Vector3.zero;
    [SerializeField]private float _rotationSpeed = 150;

    void Start()
    {
        _lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var direction = transform.position - _lastPosition;

        var targetDirection = Vector3.RotateTowards(current: transform.forward, target: direction, maxRadiansDelta: 30, maxMagnitudeDelta: Time.deltaTime);

        transform.rotation = Quaternion.LookRotation(targetDirection);

        transform.rotation = Quaternion.RotateTowards(from: transform.rotation, Quaternion.LookRotation(targetDirection), Time.deltaTime*_rotationSpeed);

        _lastPosition = transform.position;
    }
}
