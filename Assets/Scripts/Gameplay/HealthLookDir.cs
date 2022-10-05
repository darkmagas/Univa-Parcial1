using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthLookDir : MonoBehaviour
{

    public Camera _mainCam;

    void Update()
    {
        transform.LookAt(transform.position + _mainCam.transform.rotation * Vector3.back,
            _mainCam.transform.rotation * Vector3.up); 
    }
}
