using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopDirection : MonoBehaviour
{
    private Vector3 _LastPosition;
    [Header("Settings")]
    [SerializeField] private float _rotationSpeed = 10.0f;
    private void Awake()
    {
        _LastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var direction = transform.position - _LastPosition;
        var targetDirection = Vector3.RotateTowards(transform.forward, direction, 30, Time.deltaTime);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(targetDirection), Time.deltaTime * _rotationSpeed);
        _LastPosition = transform.position;
    }
}
