using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookDirection : MonoBehaviour
{
    private Vector3 _lastPosition = Vector3.zero;
    // Start is called before the first frame update
    private void Awake()
    {
        _lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       var direction = transform.position - _lastPosition;
        var targetDirection = Vector3.RotateTowards(transform.forward, direction, maxRadiansDelta:30, maxMagnitudeDelta:Time.deltaTime);
        transform.rotation = Quaternion.RotateTowards(from:transform.rotation,
        to:Quaternion.LookRotation(targetDirection),Time.deltaTime);
        _lastPosition transform.position;
    }
}
