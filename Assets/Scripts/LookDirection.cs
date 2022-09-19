using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookDirection : MonoBehaviour
{
    private Vector3 _lastposition = Vector3.zero;
    [SerializeField]private float _rotationSpeed = 150;

    // Start is called before the first frame update
    void Start()
    {
        _lastposition = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        var direction = transform.position - _lastposition;
        var targetDirection = Vector3.RotateTowards(transform.forward, direction, 30, Time.deltaTime);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(targetDirection), Time.deltaTime);
        _lastposition = transform.position;

    }
}
