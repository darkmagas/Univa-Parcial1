using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookDirection : MonoBehaviour
{
    private Vector3 _LastPosition = Vector3.zero;
    [Header("Settings")]
   [SerializeField] private float _rotationSpeed = 10.0f;
    void Start()
    {
        _LastPosition = transform.position;  
    }

    // Update is called once per frame
    void Update()
    {
        var direction = transform.position - _LastPosition;
        var targetDirection = Vector3.RotateTowards(transform.forward, direction, maxMagnitudeDelta: 30, maxRadiansDelta: Time.deltaTime);
        transform.rotation = Quaternion.RotateTowards(transform.rotation,Quaternion.LookRotation(targetDirection),Time.deltaTime);

        _LastPosition = transform.position;
    }
}
