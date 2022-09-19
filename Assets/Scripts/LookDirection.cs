using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class LookDirection : MonoBehaviour
{

    private Vector3 _lastPosition = Vector3.zero;
    [SerializeField]private float rotationSpeed = 150; 

    private void Start()
    {
        _lastPosition = transform.position;
    }

}

       
