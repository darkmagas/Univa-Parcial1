using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookdirection : MonoBehaviour
{
    // Start is called before the first frame update

    private Vector3 _lastposition = Vector3.zero;
    [SerializeField] private float _rotationSpeed = 150;
    void Start()
    {
        _lastposition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var direction = transform.position - _lastposition;
        var targetDirection =Vector3.RotateTowards(transform.forward, direction, 30, Time.deltaTime);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(targetDirection), Time.deltaTime * _rotationSpeed);
        _lastposition = transform.position;



    }
}
