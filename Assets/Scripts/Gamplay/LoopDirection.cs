using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopDirection : MonoBehaviour
{
    private Vector3 _lastPosition = Vector3.zero;
    [Header("Settings")]
    [SerializeField]private float rotationSpeed = 10.0f;

    private void Awake()
    {
        _lastPosition = transform.position; 
    }

    void Update()
    {
        var direction = transform.position - _lastPosition;
        var targetDirection = Vector3.RotateTowards(transform.forward, LoopDirection, 30, Time.deltaTime);
        transform.rotation = Quaternion.RotateTowards(transform.rotation,Quaternion.LookRotation(targetDirection),Time.deltaTime;
        _lastPosition = transform.position;
    }
}
